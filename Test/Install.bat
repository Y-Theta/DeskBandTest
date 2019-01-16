@echo off

"%~dp0gacutil.exe" /if "%~dp0BandTest.dll"
"%~dp0RegAsm.exe" "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe


Pause