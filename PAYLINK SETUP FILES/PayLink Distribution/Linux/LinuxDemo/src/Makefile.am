## Process this file with automake to produce Makefile.in

## Created by Anjuta - will be overwritten
## If you don't want it to overwrite it,
## 	Please disable it in the Anjuta project configuration

INCLUDES = \
	$(PACKAGE_CFLAGS)

AM_CFLAGS =\
	 -Wall\
	 -g

bin_PROGRAMS = AESDemo

AESDemo_SOURCES = \
	support.h\
	support.c\
	main.c\
	interface.h\
	interface.c\
	callbacks.h\
	callbacks.c\
	data_funcs.c\
	data_funcs.h

AESDemo_LDFLAGS = 

AESDemo_LDADD =  \
	$(PACKAGE_LIBS)\
	 -laes_access -lm -lrt -lftdi -lstdc++

