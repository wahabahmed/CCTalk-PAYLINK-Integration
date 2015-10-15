@echo off
cls
rem                           -- Set the following to the correct folders   <<<<<<<<<<<<<<<
Set JAVAFOLDER=C:\Program Files (x86)\Java\jdk1.7.0_60
Set VSFOLDER=C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7
rem                           --------------------------------------------------------------

PATH=%JAVAFOLDER%\bin;C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\bin
set INCLUDE=%JAVAFOLDER%\include;%JAVAFOLDER%\include\win32
call "%VSFOLDER%\Tools\vsvars32.bat"

nmake dll
