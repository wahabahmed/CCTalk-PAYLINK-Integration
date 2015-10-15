//---------------------------------------------------------------------------

#pragma hdrstop

#include <ctype.h>
#include <stdio.h>
#include <windows.h>

#include "DownloadDLL.h"

#define false 0
#define true  1

// Local Prototypes
unsigned short ReadNumber(char * CharPtr);



//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
  // local variables which hold the parameters passed on the command line
  char*          FullFileName;
  char*          Ardac5Version;
  char           InstalledArdac5Version[255];
  unsigned short ccTalkAddress;
  unsigned short Device;
  unsigned short i;
  int            VersionErrorCode;

  // keep track of which parameters have been detected
  unsigned short FilenameDefined = false;
  unsigned short AddressDefined = false;
  unsigned short DeviceDefined = false;
  unsigned short VersionRequest = false;

  printf("\n");
  printf("\n") ;
  printf("Aardvark Embedded Solutions Ltd\n");
  printf("Currency Download via PayLink - %s\n", __DATE__) ;

  // Parse the command line
  for (i = 1 ; i < argc ; ++i)
  {
    if (argv[i][0] == '/' && tolower(argv[i][1]) == 'f')
    {
      // File name
      FilenameDefined = true;
      FullFileName = &argv[i][2];
      //printf("File %s\n", FullFileName);
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'a')
    {
      // ccTalk Address
      AddressDefined = true;
      ccTalkAddress = ReadNumber(&argv[i][2]);
      //printf("ccTalk Address %u\n", ccTalkAddress);
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == 'e')
    {
      // Device Elite
      DeviceDefined = true;
      Device = DEVICE_ELITE;
      //printf("Elite\n");
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == 's')
    {
      // Device SR5i
      DeviceDefined = true;
      Device = DEVICE_SR5;
      //printf("SR5i\n");
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == 'l')
    {
      // Device Lumina
      DeviceDefined = true;
      Device = DEVICE_LUMINA;
      //printf("Lumina\n");
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == '5')
    {
      // Device Ardac5
      DeviceDefined = true;
      Device = DEVICE_ARDAC_5;
      //printf("Ardac5\n");
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'v')
    {
      // Get Ardac5 version
      DeviceDefined = true;
      Device = DEVICE_ARDAC_5;
      VersionRequest = true;
      Ardac5Version = &argv[i][2];
      //printf("Ardac5 Version \"%s\"\n", Ardac5Version);
    }
    else
    {
      // unrecognised parameter
      printf("\n");
      printf("Parameter not recognised: %s\n", &argv[i][0]) ;
    }
  }

  // check for Ardac5 version request
  if ( VersionRequest )
  {
    // Get the version from Ardac5 interface
    printf("\n");
    printf("Requesting version details from Ardac5...\n");
    VersionErrorCode = ExtractArdac5FirmwareVersion(InstalledArdac5Version);
    if ( VersionErrorCode == EXTRACT_VERSION_DEVICE_FOUND)
    {
      printf("\n");
      printf("Installed version is \"%s\"\n", &InstalledArdac5Version);

      if (strcmp(InstalledArdac5Version, Ardac5Version) == 0)
      {
        // Versions match - do not download
        printf("\n");
        printf("Versions match - File download not performed\n");
        return 0; // no problems
      }
    }
    else
    {
      printf("\n");
      printf("Failed to read version details from Ardac5. ExtractArdac5FirmwareVersion() return code = %u", VersionErrorCode);
      return 1;
    }
    if ( !FilenameDefined )
    {
      // then version request did not include download file. End program now.
      return 0;
    }
  }

  if ( FilenameDefined && DeviceDefined && (Device == DEVICE_ARDAC_5))
  {
    // download to Ardac5
    int ReturnCode = StartArdac5Download(FullFileName);

    if ( ReturnCode == START_ARDAC5_DOWNLOAD_STARTED)
    {
      // download started succesfully. The download thread is running
      int DownloadStatus;
      int Progress;

      printf("\n");
      printf("Ardac5 Download started\n");

      printf("\n");
      while ( Ardac5DownloadStatus(&DownloadStatus, &Progress) == ARDAC5_DOWNLOAD_THREAD_RUNNING)
      {
        // still running - wait update the progress display then wait 1s
        printf("\rProgress %3u of 1000. Ardac5DownloadStatus(), DownloadStatus = %u    ", Progress, DownloadStatus);
        Sleep(1000);
      }
      printf("\n");

      printf("\n");
      if ( DownloadStatus == ARDAC5_DOWNLOAD_STATUS_TRANSFER_COMPLETE )
      {
        printf("Ardac5 download completed successfully\n");
      }
      else
      {
        printf("Ardac5 download finished with errors:\n");
        printf("  DownloadStatus    = %u\n", DownloadStatus);
        printf("  Progress          = %u\n", Progress);
      }
    }
    else
    {
      // The application failed to start the download thread
      printf("\n");
      printf("Ardac5 download not started. StartArdac5Download() return code = %u\n", ReturnCode);
    }
  }
  // if all parameters defined then start the download to SR5i, Ardac Elite or Lumina
  else if ( FilenameDefined && AddressDefined && DeviceDefined )
  {
    unsigned short ReturnCode;

    // the next call starts the download thread then returns with the thread still running
    // The second parameter is not used for downloads via PayLink and can be left as zero.
    ReturnCode = StartDefinitionDownload(FullFileName, 0, ccTalkAddress, Device);

    if ( ReturnCode == START_DOWNLOAD_TRANSMISSION_STARTED)
    {
      // download started succesfully. The download thread is running
      unsigned short DownloadStatus;
      unsigned short TerminationStatus;
      unsigned short Progress;
      unsigned short ProgressLimit;

      printf("\n");
      printf("Download started\n");

      printf("\n");
      while ( DefinitionDownloadStatus(&DownloadStatus, &TerminationStatus, &Progress, &ProgressLimit) == DOWNLOAD_THREAD_RUNNING)
      {
        // still running - wait update the progress display then wait 1s
        printf("\rProgress %3u of %3u. Download status %u    ", Progress, ProgressLimit, DownloadStatus);
        Sleep(1000);
      }
      printf("\n");

      printf("\n");
      if ( TerminationStatus == TERMINATION_STATUS_TRANSMISSION_SUCCESS )
      {
        printf("Download completed successfully\n");
      }
      else
      {
        printf("Download finished with errors:\n");
        printf("  DownloadStatus    = %u\n", DownloadStatus);
        printf("  TerminationStatus = %u\n", TerminationStatus);
        printf("  Progress          = %u\n", Progress);
        printf("  ProgressLimit     = %u\n", ProgressLimit);
      }
    }
    else
    {
      // The application failed to start the download thread
      printf("\n");
      printf("Download not started. StartDefinitionDownload() return code = %u\n", ReturnCode);
    }
  }
  else
  {
    // There was an error with the parameters passed to the application
    // Display help
    printf("\n");
    printf("Multipurpose download program. Files are downloaded via the AESWDriver connection to PayLink.\n") ;
    printf("The following downloads are performed by this program:\n") ;
    printf("  - Download a coin definition file to an SR5i Coin Acceptor\n") ;
    printf("  - Download a note definition file to an Ardac Elite Note Acceptor\n") ;
    printf("  - Download a note definition file to a Lumina Note Acceptor\n") ;
    printf("  - Download a firmware and note definition file to an Ardac5 Note Acceptor\n") ;
    printf("\n") ;
    printf("PayLinkDownload /f## /d# /a## /v## \n");
    printf("\n") ;
    printf("  For all downloads:\n");
    printf("  /f##         Name and path of download file\n") ;
    printf("\n");
    printf("  For downloads to SR5i, Elite and Lumina:\n");
    printf("  /ds          Device is SR5i\n");
    printf("  /de          Device is Ardac Elite\n");
    printf("  /dl          Device is Lumina\n");
    printf("  /a##         The ccTalk address of the target device (in decimal)\n");
    printf("\n");
    printf("  For downloads to Ardac5:\n");
    printf("  /d5          Device is Ardac5\n");
    printf("  /v##         Check the Ardac5 version. \n");
    printf("               - If the filename is not supplied then ## is ignored and the Ardac5\n");
    printf("                 version is reported\n");
    printf("               - If filename is supplied then the download only performed if the\n");
    printf("                 installed version does not match ## in the parameter list\n");
  }

  printf("\n") ;
  return 0;
}


/*
 *  TITLE       ReadNumber
 *  PARAMETERS  Pointer to an ascii number
 *  RETURN      Value of the ascii string
 *  FUNCTION    Convert the ascii string to the numberic value.
 */

unsigned short ReadNumber(char * CharPtr)
{
  unsigned short ReturnVal = 0;
  unsigned short Byte = *CharPtr++;

  while ( Byte >= '0' && Byte <= '9' )
  {
    // found a valid digit so scale up previous value and add new digit.
    ReturnVal *= 10;
    ReturnVal += Byte - '0';
    Byte = *CharPtr++;
  }
  return ReturnVal;
}


