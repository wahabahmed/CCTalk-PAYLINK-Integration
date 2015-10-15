@echo off
rem                           -- Set the following to the correct folders   <<<<<<<<<<<<<<<
Set JAVAFOLDER=E:\Program Files\Java\jdk1.6.0_22
Set VSFOLDER=E:\Large Packages\Microsoft Visual Studio 8
rem                           --------------------------------------------------------------

PATH=%JAVAFOLDER%\bin
set INCLUDE=%JAVAFOLDER%\include;%JAVAFOLDER%\include\win32

javah -jni -classpath AESImhei.jar aes.imhei.AESImhei
call "%VSFOLDER%\VC\Vcvarsall.bat" x86_amd64
cl -I"." -I".." -MT -LD AESImheiJava.cpp ..\AESImhei64.lib -FeAESImheiJava64.dll  


