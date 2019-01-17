@echo off

"%~dp0RegAsm.exe" /nologo /codebase "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause