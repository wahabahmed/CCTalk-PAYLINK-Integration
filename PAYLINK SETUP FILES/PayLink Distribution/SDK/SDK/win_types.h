/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#ifndef __WIN_TYPES__
#define __WIN_TYPES__

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#define MAX_NUM_DEVICES 50
#include <sys/time.h>
#include <unistd.h>


/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#if !(defined (_MSC_VER) || (defined (__GNUC__) && defined (__WIN32__)))
#define __cdecl
#define __stdcall
#define __fastcall
#endif

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
typedef unsigned int                    DWORD;
typedef unsigned int                    ULONG;
typedef unsigned short                   USHORT;
typedef short                                    SHORT;
typedef unsigned char                    UCHAR;
typedef unsigned short                   WORD;
typedef unsigned char                    BYTE;
typedef unsigned char                   *LPBYTE;
typedef int                                      BOOL;
typedef char                                     BOOLEAN;
typedef char                                     CHAR;
typedef int                                     *LPBOOL;
typedef unsigned char                   *PUCHAR;
typedef const char                              *LPCSTR;
typedef char                                    *PCHAR;
typedef void                                    *PVOID;
typedef int                                     LONG;
typedef int                                      INT;
typedef unsigned int                     UINT;
typedef char                                    *LPSTR;
typedef char                                    *LPTSTR;
typedef DWORD                                   *LPDWORD;
typedef WORD                                    *LPWORD;
typedef ULONG                                   *PULONG;
typedef PVOID                                    LPVOID;
typedef void                                     VOID;
typedef unsigned long long int   ULONGLONG;

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
typedef struct _SECURITY_ATTRIBUTES
{       DWORD   nLength;
        LPVOID  lpSecurityDescriptor;
        BOOL    bInheritHandle;
} SECURITY_ATTRIBUTES , *LPSECURITY_ATTRIBUTES;

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
typedef struct timeval SYSTEMTIME;
typedef struct timeval FILETIME;

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#ifndef TRUE
#define TRUE    1
#endif

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#ifndef FALSE
#define FALSE   0
#endif

/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/

#define Sleep(n)  { \
                    if (n > 1000) \
                        sleep(n / 1000) ; \
                    else \
                        usleep(n * 1000) ; \
                  }


/*---------------------------------------------------------------------------*\
 *
\*---------------------------------------------------------------------------*/
#endif
