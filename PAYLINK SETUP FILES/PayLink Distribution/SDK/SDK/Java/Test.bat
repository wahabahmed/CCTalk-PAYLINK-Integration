call build.bat
javac -classpath AESImhei.jar Tester.java
echo .
echo .
echo .
set CLASSPATH=.;AESImhei.jar
java Tester
pause
