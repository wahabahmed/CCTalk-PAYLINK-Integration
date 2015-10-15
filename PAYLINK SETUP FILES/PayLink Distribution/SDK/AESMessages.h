/* --------------------------------------------------------------------------

        File Name:              AESMessages.h

        Project:                Aardvark Game Interface

        Copyright:              © Aardvark Embedded Solutions Ltd. 2003

                                This is the description of the messages
                                that are passed between the PC and the H8
                                across the PCI interface.

   -------------------------------------------------------------------------- */
#ifndef __AESMESSAGES_H
#define __AESMESSAGES_H

enum MessageCodes
    {
    MONITOR_INPUT,
    START_REPROGRAM,
    PROGRAM_DATA,
    END_REPROGRAM,
    RESET_EEPROM,
    SET_DEVICE_SERIAL_NO,
    DATA_FOR_PRINTER,
    COPYRIGHT_QUERY        = 0x3F,
    APPLICATION_INTERFACES = 0x40,
    RAW_PORT_OFFSET        = 0x80,

    PRINTER_DATA_BLOCK     = 32
    } ;


#define ADDRESS_LENGTH 3
typedef struct
    {
    AESLong Code ;                     // == PROGRAM_DATA
    AESLong Length ;
    char Address[ADDRESS_LENGTH] ;  // MS Byte 1st
    unsigned char Data[128] ;
    } ProgramBlock ;


typedef struct
    {
    AESLong Code ;
    AESLong Length ;
    char Data[1024] ;
    } CommandBlock ;

#endif
