<a>
  <img src="https://github.com/mmazzanti/WavemeterService/blob/master/WM_service_Logo.svg" width="100%" height="160">
</a>

WavemeterService is composed by three elements :
* Installer : Installs the Wavemeter service or App
* Wavemeter Service : A windows service that takes in charge to read the data (Wavelength and Spectral analysis) from the wavemeter and sends the data on a UDP connection
* Wavemeter Service Manager : Controls the Service, easy way to start/stop/restart it
* Wavemeter Sharing App : An app that does the same as Wavemeter service + Wavemeter service Manager

The main idea is to use a Windows service to share the data coming from a wavemeter (Highfinesse), we want to be able to access the Wavelength and the spectral analysis from any PC on the network. The data is shared on a UDP connection. The broadcast address is choosed automatically by the program based on the network interface selected (eg. when connected to a Local Area Network with IP address 10.10.12.202/255 the calcualted broadcast address will be 10.10.12.255.
The shared data can be easily read using python/c++ etc... For our purpose we'll need to integrate the reading procedure in one c++ software that we use to control the experiment, I will write the code in the following days and (perhaps) post it on github.
For an easy python example have a look at the folder Examples

## Wavemeter Sharing App ##
### GUI ###

<a>
  <img src="https://github.com/mmazzanti/WavemeterService/blob/master/Icons/WavemeterSharingApp.png" width="50%" height="50%">
</a>
- - - -
The software is self eplanatory; however here's a short explanation!
* Start/stop buttons start and stop of sharing data on the UDP connection
* Status button (running, in green in the image) : Gives a live update on the status of the program. If sharing data the icon will be green (with running text) otherwise red (with stopped text)
* Channels to share : to avoid flooding the network with big amount of data is useful to choose only the channels one is interested into
* Logging area : A text box for logging the activities of the sofware (mostly user based)
* Network settings : Interface and delay time to be used on the network. The delay time in ms is the delay between two UDP packets on the network (hardcoded to be > 10ms)

### User settings ###
All settings besides network ones are normally saved when changed and recovered in case of restart of the computer.
The Network settings can be saved using the save button. This to make it harder for people to screw the software up...

### Taskbar menu ###
When minimized or closed the program will still run in background, to terminate it fully use the taskbar controls.
Taskbar controls
<a>
  <img src="https://github.com/mmazzanti/WavemeterService/blob/master/Icons/WavemeterSharingAppMenu.png" width="30%" height="30%">
</a>

