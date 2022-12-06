# Lenovo Battery Powershell Module

A lighweight powershell module for handling the battery mode for now. This repository is a fork from https://github.com/reagcz/IdeapadToolkit and all credits from communicating with the `PowerBattery.dll` go to [reacz](https://github.com/reagcz).

## Supported laptops
- Probably any laptop that can be handled by Lenovo Vantage?

## Prerequisites
- PowerBattery.dll
  - This dll needs to be placed in the same directory as the executable
  
### How to get PowerBattery.dll
- Method A
  1. Install Lenovo Vantage from the Microsoft Store
  2. Copy it from C:\ProgramData\Lenovo\Vantage\Addins\IdeaNotebookAddin\ to the Ideapad Toolkit directory
  3. Lenovo Vantage can now be uninstalled
- Method B (Without Microsoft Store)
  1.  Go to https://store.rg-adguard.net/
  2.  Enter the link to Lenovo Vantage (https://apps.microsoft.com/store/detail/lenovo-vantage/9WZDNCRFJ4MV)
  3.  Download the newest version in the **.msixbundle** format (The file should be called "something LevovoCompanion something **.msixbundle**)
  4.  Open the .msixbundle file using 7Zip or similar software
  5.  Inside 7Zip, navigate to LenovoVantagePackage\[Version\]x64.msix/DeployAssistant/ImController/Plugins\[Version\].cab/plugins.7z/Normal/IdeaNotebookPlugin/x64
  6.  PowerBattery.dll should be in there


 ## Third party licenses
 [reagcz/IdeapadToolkit](https://github.com/reagcz/IdeapadToolkit/blob/main/LICENSE)
