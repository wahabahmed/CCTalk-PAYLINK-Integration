#-----------------------------------------------------------------------------
# File Name: makefile
# Description
# -----------
# This is the makefile for the AESImhei.java project.
#
# Externally to this, the Path, Include path and Library paths must have been set up.
#				The Include path has to include the Java SDK includes
#
#-----------------------------------------------------------------------------
SHELL	= /bin/sh
LIBS		 = -lm -lrt -laes_access -lstdc++ 

.PHONEY: None
None: 
	echo Specify either so or dll

#-- Main targets --------------------------------------------------------------

.PHONEY: dll
dll: 	AESImheiJava.dll 

.PHONEY: so
so: 	libAESImheiJava.so.1.2.0

#-- Clean Up -----------------------------------------------------------------

.PHONEY: clean
clean:
	rm -f *.[bo]
	rm -f *.err
	rm -f /usr/local/lib/*AESImheiJava*
	rm -f libAESImheiJava.a AESImheiJava.jar libAESImheiJava.* \
				aes_imhei_AESImheiJava.h 1>/dev/null 2>&1
#-- Install ------------------------------------------------------------------

.PHONEY: install
install:
	cp libAESImheiJava.so.1.2.0  /usr/local/lib/
	/sbin/ldconfig
	ln -sf /usr/local/lib/libAESImheiJava.so.1.2.0 /usr/local/lib/libAESImheiJava.so
	ln -sf /usr/local/lib/libAESImheiJava.so.1.2.0 /usr/local/lib/libAESImheiJava.so.1


#-- Build targets ------------------------------------------------------------
AESImhei.jar: AESImhei.java
	javac  -d . AESImhei.java
	jar -cf AESImhei.jar .

aes_imhei_AESImhei.h: AESImhei.jar
	javah -jni -classpath AESImhei.jar aes.imhei.AESImhei


AESImheiJava.dll: AESImheiJava.cpp aes_imhei_AESImhei.h
	cl -I"." -I".." -MT -LD AESImheiJava.cpp ..\AESImhei.lib -FeAESImheiJava.dll  



libAESImheiJava.so.1.2.0: AESImheiJava.cpp aes_imhei_AESImhei.h
	$(CXX) -fPIC -g -c $(CXXFLAGS) AESImheiJava.cpp
	$(CC) -shared -Wl,-soname,libAESImheiJava.so.1 $(LIBS) \
		-o $@ AESImheiJava.o -lc
	rm -rf aes

#------------------------------ END OF FILE ----------------------------------

