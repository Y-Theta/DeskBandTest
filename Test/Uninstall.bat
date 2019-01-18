@echo off

"%~dp0tools\gacutil.exe" /nologo /u "%~dp0WindowsDeskBand.dll"
"%~dp0tools\gacutil.exe" /nologo /u "%~dp0WPFBand.dll"
"%~dp0tools\gacutil.exe" /nologo /u "%~dp0BandTest.dl\
"%~dp0tools\RegAsm.exe" /nologo /unregister "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause