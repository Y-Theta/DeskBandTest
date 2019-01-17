@echo off

"%~dp0tools\RegAsm.exe" /nologo /unregister "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause