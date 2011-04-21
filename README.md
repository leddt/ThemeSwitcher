ThemeSwitcher
=============

A Visual Studio 2008/2010 add-in for switching between multiple 
color settings.

## Installation

Simply copy ThemeSwitcher.vs2008.AddIn (or ThemeSwitcher.vs2010.AddIn) 
and ThemeSwitcher.dll in `My Documents\Visual Studio 20xx\Addins` and 
restart Visual Studio.

## Usage

In Visual Studio, go to `Tools -> ThemeSwitcher Configuration` to open
the configuration dialog. From there, add your desired vssettings files
and make sure they are checked in the list.

You can then press `Ctrl+#` to load the next settings file. This shortcut key
may be modified in 
`Tools -> Options -> Environment -> Keyboard -> ThemeSwitcher.Connect.Next`.

ThemeSwitcher is intended to switch between color schemes, however it will load
the full content of any vssettings file. Thus it may be used to switch between
keyboard layouts, editor settings and other Visual Studio options.