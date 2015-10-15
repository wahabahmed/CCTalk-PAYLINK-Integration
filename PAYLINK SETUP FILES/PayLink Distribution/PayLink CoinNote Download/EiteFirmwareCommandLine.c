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
  char           InstalledArdac5Version[255];
  unsigned short Device;
  unsigned short i;
  int            VersionErrorCode;

  // keep track of which parameters have been detected
  unsigned short FilenameDefined = false;
  unsigned short DeviceDefined = false;

  printf("\n");
  printf("\n") ;
  printf("Aardvark Embedded Solutions Ltd\n");
  printf("Elite Downloads via PayLink - %s\n", __DATE__) ;

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
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == 'c')
    {
      DeviceDefined = true ;
      Device = DEVICE_ELITE ;
    }
    else if (argv[i][0] == '/' && tolower(argv[i][1]) == 'd' && tolower(argv[i][2]) == 'f')
    {
      DeviceDefined = true ;
      Device = DEVICE_ELITE_FIRMWARE ;
    }
    else
    {
      // unrecognised parameter
      printf("\n");
      printf("Parameter not recognised: %s\n", &argv[i][0]) ;
    }
  }


 if ( FilenameDefined && DeviceDefined )
  {
    unsigned short ReturnCode;

    // the next call starts the download thread then returns with the thread still running
    // The second parameter is not used for downloads via PayLink and can be left as zero.
    ReturnCode = StartDefinitionDownload(FullFileName, 0, CCTALK_ADDRESS_DEFAULT_ARDAC_ELITE_NOTE_ACCEPTOR, Device);

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
    printf("Multipurpose Elite download program. Files are downloaded via the AESWDriver connection to PayLink.\n") ;
    printf("The following downloads are performed by this program:\n") ;
    printf("  - Download a firmware definition file to an Ardac Elite Note Acceptor\n") ;
    printf("  - Download a note definition file to an Ardac Elite Note Acceptor\n") ;
    printf("\n") ;
    printf("PayLinkDownload /f## /d#\n");
    printf("\n") ;
    printf("  For all downloads:\n");
    printf("  /f##         Name and path of download file\n") ;
    printf("\n");
    printf("  /df          Type is Firmware\n");
    printf("  /dc          Type is Coin\n");
    printf("\n");
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


