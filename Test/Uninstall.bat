@echo off

"%~dp0gacutil.exe" /u "BandTest,Version=1.0.0.0, Culture=neutral"
"%~dp0RegAsm.exe" /u "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause