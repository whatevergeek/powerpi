# PowerPi
## a powershell module that wraps raspberry pi gpio
### Author: Paul Lorett Amazona (whatevergeek)

[Click Here for video demo](https://www.instagram.com/p/BG1qOs_MXQN/?taken-by=what3v3rg33k)


#### Setup 
Once your WinIoT is already setup for your Pi,  
connect the positive side of your LED to GPIO 5 pin  
and the negative side to the ground (GND) pin  
For setup, load the PowerPiLib.dll in WinIoT powershell   console (accessed via Powershell Remoting).   
PowerPiLib.dll is generated from the C# solution  
You may use the files from the link below  
 if you don't want to build:  
https://github.com/whatevergeek/powerpi/tree/master/PowerPiApp/PowerPiLib/bin/ARM/Debug


#### Sample Usage
```powershell
Add-Type -Path .\PowerPiLib.dll
$ioValue = New-Object PowerPiLib.GpioValue
$ioHelper = New-Object PowerPiLib.GpioHelper

#To turn on LED:
$ioHelper.Pin = $ioValue::High

#To turn off LED:
$ioHelper.Pin = $ioValue::Low 

#To blink every 1 second
while($true)
{
    $ioHelper.Pin = @{$true=$ioValue::Low;$false=$ioValue::High}[$ioHelper.Pin -eq $ioValue::High]  
    start-sleep -m 1000
}

```