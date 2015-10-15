#-----------------------------------------------------------------------------
# File Name: makefile
# Description
# -----------
# This is the makefile for the LuminaSerial project.
#
#-----------------------------------------------------------------------------
SHELL 		= /bin/sh
EXECUTABLES	= LuminaSerial

#-- Release Compiler Flags ---------------------------------------------------

CFLAGS		+= -O2 -g0 -Wall -pedantic -Wstrict-prototypes -std=c99
CFLAGS		+= -pipe -fomit-frame-pointer -D_GNU_SOURCE 

#-- Required libraries -------------------------------------------------------

LIBS		 = -lm -lrt -laes_access -lstdc++ 

#-- Dependencies -------------------------------------------------------------

OBJS = LuminaSerial.o 

#-- Compile All --------------------------------------------------------------

.PHONEY: all
all: 	$(EXECUTABLES)

#-- Clean Up -----------------------------------------------------------------

.PHONEY: clean
clean:

	rm -f *.[bo]
	rm -f *.err
	rm -f $(EXECUTABLES)

#-- Build targets ------------------------------------------------------------

LuminaSerial: $(OBJS)
		$(CC) $(OBJS) $(CFLAGS) $(LIBS) -o $@

#------------------------------ END OF FILE ----------------------------------

