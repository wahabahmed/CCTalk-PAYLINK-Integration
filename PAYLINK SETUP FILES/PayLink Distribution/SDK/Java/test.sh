#!/bin/sh
# make so
# make install
echo .
echo .
echo .
javac -classpath AESImhei.jar Tester.java
export CLASSPATH=.:./AESImhei.jar:$CLASSPATH
export LD_LIBRARY_PATH=/usr/local/lib:$LD_LIBRARY_PATH
echo .
java Tester
