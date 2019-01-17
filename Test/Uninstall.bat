@echo off

"%~dp0gacutil.exe" /unregister "BandTest,Version=1.0.0.0, Culture=neutral"
"%~dp0gacutil.exe" /unregister "WindowsDeskBand,Version=1.0.0.0, Culture=neutral"
"%~dp0gacutil.exe" /unregister "WPFBand,Version=1.0.0.0, Culture=neutral"
"%~dp0RegAsm.exe" /unregister "%~dp0BandTest.dll"

taskkill /f /im "explorer.exe"
start explorer.exe

Pause