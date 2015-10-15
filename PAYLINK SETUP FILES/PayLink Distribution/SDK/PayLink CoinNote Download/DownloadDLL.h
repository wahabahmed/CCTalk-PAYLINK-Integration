/* ------------------------------------------------------------------------------------------
 *
 * This file defines the DLL entry points for coin and note definition downloads via PayLink
 * or ShereLink to SR5i, Ardac Elite, Ardac5 and Lumina.
 *
 * The only difference between the PayLink and ShereLink downloads is that the ComPortNumber
 * is not used for downloads via PayLink.
 *
 * Ardac5 downloads use a different DLL but use this include file.
 *
 * Change History
 *
 *    Date        By    Change
 *    ====        ==    ======
 *
 *    6/3/2008    AJT   Original Issue.
 *
 * ------------------------------------------------------------------------------------------*/


// This section allows the DLL to be linked to Visual Basic application as well as Visual C and C++ .
#ifdef __cplusplus
extern "C" {
#endif

#ifndef DLL         // user application
 #define DLL __declspec(dllimport) __stdcall
#endif


// ************************************************************************************************************************
// Function:  Set the Encryption serial number if not the default 123456.
// Acceptors: Ardac Elite and Lumina.
// Interface: PayLink, ShereLink
// ************************************************************************************************************************
void DLL SetEncryptionSerialNumber(int  NewBCDSerial) ;

// NewBCDSerial number is the new encryption number.


// ************************************************************************************************************************
// Function:  Start the transfer of a coin or note definition to the target device.
//            When the download completes PayLink / ShereLink are reset.
// Acceptors: SR5i, Ardac5, Ardac Elite and Lumina.
// Interface: PayLink, ShereLink
// ************************************************************************************************************************
unsigned short DLL StartDefinitionDownload(char * FullFileName, unsigned short ComPortNumber, unsigned short ccTalkAddress, unsigned short Device);

// FullFileName is a pointer to the path and file name of the coin or note definition file.

// ComPortNumber is the port that is the USB driver for ShereLink. e.g. 3 for Com3.
// Not relevant for PayLink downloads. Set to 0 for downloads via PayLink.

// ccTalkAddress is the ccTalk address of the target device. Options are:
// PayLink addresses
#define CCTALK_ADDRESS_DEFAULT_SR5_COIN_ACCEPTOR          2
#define CCTALK_ADDRESS_DEFAULT_ARDAC_ELITE_NOTE_ACCEPTOR  40
#define CCTALK_ADDRESS_DEFAULT_LUMINA_NOTE_ACCEPTOR       40

// ShereLink addresses
#define CCTALK_ADDRESS_SR5_COIN_SORTER                    11
#define CCTALK_ADDRESS_SR5_COIN_ACCEPTOR                  12
#define CCTALK_ADDRESS_ARDAC_ELITE_NOTE_ACCEPTOR          40

// Device is the type of device being updated. Options are:
#define DEVICE_SR5                                        0
#define DEVICE_ELITE                                      1
#define DEVICE_LUMINA                                     2
#define DEVICE_ARDAC_5                                    3
#define DEVICE_ELITE_FIRMWARE                             4

// StartDefinitionDownload() return codes
#define START_DOWNLOAD_TRANSMISSION_STARTED               0
#define START_DOWNLOAD_CANNOT_START_THREAD                1
#define START_DOWNLOAD_CANNOT_START_UNKNOWN_DEVICE        2
#define START_DOWNLOAD_THREAD_ALREADY_RUNNING             3



// ************************************************************************************************************************
// Function:  Check the status of the transfer to the target device. Data returned refers to the last
//            StartDefinitionDownload() that returned START_DOWNLOAD_TRANSMISSION_STARTED
// Acceptors: Sr5i, Ardac5, Ardac Elite and Lumina.
// Interface: PayLink, ShereLink
// ************************************************************************************************************************
unsigned short DLL DefinitionDownloadStatus(unsigned short * DownloadStatus, unsigned short * TerminationStatus, unsigned short * Progress, unsigned short * ProgressLimit);

// DownloadStatus returns the current status of the download.
// Valid if the return value == DOWNLOAD_THREAD_RUNNING
// Options are:
#define DOWNLOAD_STATUS_PROCESS_IDLE                      0
#define DOWNLOAD_STATUS_CHECKING_FILE                     1
#define DOWNLOAD_STATUS_OPENING_INTERFACE                 2
#define DOWNLOAD_STATUS_ENABLING_INTERFACE                3
#define DOWNLOAD_STATUS_SEARCHING                         4
#define DOWNLOAD_STATUS_REQUESTING_BUS                    5
#define DOWNLOAD_STATUS_POLLING                           6
#define DOWNLOAD_STATUS_ERASING_COINS                     7
#define DOWNLOAD_STATUS_STARTING_UPGRADE                  8
#define DOWNLOAD_STATUS_TURNING_OFF_ENCRYPTION            9
#define DOWNLOAD_STATUS_TRANSFER_IN_PROGRESS              10
#define DOWNLOAD_STATUS_TRANSFER_COMPLETE                 11
#define DOWNLOAD_STATUS_WAITING                           12
#define DOWNLOAD_STATUS_RESETTING                         13
#define DOWNLOAD_STATUS_RELEASE_BUS                       14
#define DOWNLOAD_STATUS_FINAL_WAIT                        15
#define DOWNLOAD_STATUS_RESET_PAYLINK                     16
#define DOWNLOAD_STATUS_COMPLETE                          17  // check Termination status for success/failure

// TerminationStatus is the reason the download stopped.
// Valid if the return value == DOWNLOAD_THREAD_STOPPED
// Options are:
#define TERMINATION_STATUS_TRANSMISSION_SUCCESS           0
#define TERMINATION_STATUS_FILE_OPEN_FAILED               1
#define TERMINATION_STATUS_FILE_INTERNALLY_INCONSISTENT   2
#define TERMINATION_STATUS_OPEN_INTERFACE_FAILED          3
#define TERMINATION_STATUS_DEVICE_SEARCH_FAILED           4
#define TERMINATION_STATUS_NOT_RESPONDING                 5
#define TERMINATION_STATUS_DIALOGUE_ERROR                 6
#define TERMINATION_STATUS_FILE_READ_FAILED               7
#define TERMINATION_STATUS_UNKNOWN_DEVICE                 8
#define TERMINATION_STATUS_DOWNLOAD_NOT_FINISHED          9

// Progress is an ongoing count of the blocks sent to the device
// Valid if the return value == DOWNLOAD_THREAD_RUNNING

// ProgressLimit is the number of blocks that will be sent to the device
// Valid if the return value == DOWNLOAD_THREAD_RUNNING

// DefinitionDownloadStatus() return the status of the download thread.
// Options are:
#define DOWNLOAD_THREAD_STOPPED                           0
#define DOWNLOAD_THREAD_RUNNING                           1



// ************************************************************************************************************************
// Function:  Close the com port opened to ShereLink. Only required if the DLL remains running after the download has
//            completed. e.g. if the DLL is linked into the Shere application. No need to call is using the ShereDownload.exe
// Acceptors: N/A
// Interface: ShereLink
// ************************************************************************************************************************
void DLL CloseComPort(void);




// ************************************************************************************************************************
// Function:  Read the current firmware version of the Ardac5 validator connected to PAyLink port 9.
// Acceptors: Ardac5
// Interface: PayLink
// ************************************************************************************************************************
int DLL ExtractArdac5FirmwareVersion(char * DestinationBuffer);

// DestinationBuffer is the place to put the firmware version. Buffer size ???

// return codes
#define EXTRACT_VERSION_DEVICE_FOUND                      0
#define EXTRACT_VERSION_OPEN_INTERFACE_FAILED             1
#define EXTRACT_VERSION_DOWNLOAD_IN_PROGRESS              2
#define EXTRACT_VERSION_INTERFACE_TIMEOUT                 3



// ************************************************************************************************************************
// Function:  Start the firmware and note definition download to the Ardac5 connected to PAyLink port 9.
// Acceptors: Ardac5
// Interface: PayLink
// ************************************************************************************************************************
int DLL StartArdac5Download(char * FileName);

// FileName is a pointer to the path and filename of the file to be downloaded.

// return codes
#define START_ARDAC5_DOWNLOAD_STARTED                     0
#define START_ARDAC5_DOWNLOAD_INVALID_FILE                1
#define START_ARDAC5_DOWNLOAD_CANNOT_OPEN_FILE            2
#define START_ARDAC5_DOWNLOAD_NO_COMMS                    3
#define START_ARDAC5_DOWNLOAD_THREAD_ALREADY_RUNNING      4
#define START_ARDAC5_DOWNLOAD_CANNOT_START_THREAD         5


// ************************************************************************************************************************
// Function:  Get the status of the firmware and note definition download to the Ardac5 connected to PAyLink port 9.
// Acceptors: Ardac5
// Interface: PayLink
// ************************************************************************************************************************
int DLL Ardac5DownloadStatus(int * DownloadState, int * Progress);

// Download state
// Valid if return ARDAC5_DOWNLOAD_THREAD_RUNNING.
#define ARDAC5_DOWNLOAD_STATUS_PROCESS_IDLE               0
#define ARDAC5_DOWNLOAD_STATUS_NO_RESPONSE                1
#define ARDAC5_DOWNLOAD_STATUS_REQUESTING_BUS             2
#define ARDAC5_DOWNLOAD_STATUS_POLLING                    3
#define ARDAC5_DOWNLOAD_STATUS_TRANSFER_COMPLETE          4

// Progress is the percentage completed (x10) i.e. 0-1000.
// Valid if return ARDAC5_DOWNLOAD_THREAD_RUNNING.

// return codes
#define ARDAC5_DOWNLOAD_THREAD_STOPPED                    0
#define ARDAC5_DOWNLOAD_THREAD_RUNNING                    1


#ifdef __cplusplus
}
#endif

