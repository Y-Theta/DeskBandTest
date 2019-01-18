@echo off

"%~dp0tools\gacutil.exe" /nologo /i "%~dp0WindowsDeskBand.dll"
"%~dp0tools\gacutil.exe" /nologo /i "%~dp0WPFBand.dll"
"%~dp0tools\gacutil.exe" /nologo /i "%~dp0BandTest.dll"
"%~dp0tools\RegAsm.exe" /nologo /codebase "%~dp0BandTest.dll"

Pause