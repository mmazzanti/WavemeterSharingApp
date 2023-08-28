[![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/banner2-direct.svg)](https://stand-with-ukraine.pp.ua)
<a>
  <img src="https://github.com/mmazzanti/WavemeterService/blob/master/WM_service_Logo.png" width="100%" height="160">
</a>

# Wavemeter Sharing App

WavemeterSharingApp is a Windows application designed for sharing wavelengths obtained from Toptica:tm:/HighFinesse:tm: wavelength meters.

## Releases ##
Wavemeter sharing app is available for windows only as the manufacturer wavemeter software is provided only for windows platforms.

You can download the last version installer here: [Wavemeter App Installer](https://github.com/mmazzanti/WavemeterService/releases/tag/v1)

<a href="https://www.buymeacoffee.com/mmazzanti" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

## Project Overview

The repository encompasses several components, with a focus on facilitating the sharing of wavelength data:

- **Wavemeter Service (deprecated):** Initially conceived as a Windows service, this module was responsible for reading wavelength and spectral analysis data from the wavemeter and transmitting it over a UDP connection.

- **Wavemeter Service Manager (deprecated):** This utility was created to provide effortless control over the Wavemeter Service, simplifying tasks like starting, stopping, and restarting the service.

- **Wavemeter Sharing App:** The core component of this project, the Wavemeter Sharing App, combines the functionality of both the Wavemeter Service and Wavemeter Service Manager into a user-friendly application.

- **Installers:** This section houses installation packages for both the Wavemeter Service and the Wavemeter Sharing App.

## Rationale for Deprecation

The decision to deprecate the Wavemeter Service and Wavemeter Service Manager was influenced by challenges related to loading a DLL at startup without interfering with the manufacturer's default wavemeter application. The Wavemeter Sharing App is the recommended replacement.

## Usage and Data Sharing

The application allows seamless sharing of data from a wavemeter (Toptica:tm:/Highfinesse:tm:), enabling access to wavelength and spectral analysis information from any PC on the network. Data transmission occurs over a UDP connection, with the broadcast address automatically determined based on the selected network interface (e.g., when connected to a Local Area Network with IP address 10.10.12.202/255, the calculated broadcast address will be 10.10.12.255).

Data is serialized using JSON, ensuring compatibility with various programming languages that offer libraries for UDP network communication (e.g., Python, C++). For a straightforward Python example, consult the "Examples" folder.

## Important Considerations

- **Serialization Impact:** To maintain data accessibility, wavelengths and patterns are serialized using JSON. While this enhances data readability and debugging, it significantly increases network usage. It is advisable to share patterns for only the essential channels and disable pattern sharing when not needed. The software provides the flexibility to adjust the ratio between packages containing laser wavelengths and those including patterns.

- **DLL Requirement:** Please note that both installers do not include the wmData.dll required for communication with the wavemeter via USB. This DLL must match the one used by the manufacturer's software (typically installed in sys32 or sysWOW64). If you have the manufacturer's software already installed, the Wavemeter Service will function without additional DLLs. However, for debugging, testing, or other purposes on a PC where the manufacturer's software is absent, a custom installation is necessary to include the wmData.dll.

<!---
WavemeterService is a windows application for sharing wavelengths obtained from Toptica:tm:/HighFinesse:tm: wavelenght meters.

The project comprises various elements, some of which are deprecated :

* *Wavemeter Service* (deprecated) : A windows service that takes in charge to read the data (Wavelength and Spectral analysis) from the wavemeter and sends the data on a UDP connection
* *Wavemeter Service Manager* (deprecated) : Controls the Service, easy way to start/stop/restart it
* *Wavemeter Sharing App* : An app that does the same as Wavemeter service + Wavemeter service Manager
* *Installers* : Install the Wavemeter service or App

I had to abandon the idea of running the wavemeter sharing software as a windows service to the various challenges on loading a Dll at startup without interfering with the normal work of the default wavemeter application, provided by the manufacturer.

The application can be used to share the data coming from a wavemeter (Toptica:tm:/Highfinesse:tm:), alowing to access the wavelength and the spectral analysis from any PC on the network. The data is shared on a UDP connection. The broadcast address is choosed automatically by the program based on the network interface selected (eg. when connected to a Local Area Network with IP address 10.10.12.202/255 the calcualted broadcast address will be 10.10.12.255.

The shared data is serialized using json and can be easily read using any programming language that offers libraries for interfacing with a UDP network connection (python/c++ etc..). For an easy python example have a look at the folder Examples

__IMPORTANT__ : In order to keep the data easily accessible I decided to serialise the wavelengths and patterns using json. While this allows for easier debugging and higher readabily of the data, it increases the network usage considerably. For these reasons I suggest to share the patterns of the few channels one cares about and switch the pattern sharing off when not needed. Furthermore, the software distinguishes between UPD packages containing only the laser wavelengths and UDP packages containing wavelengths + patterns. The settings allows the user to choose the ratio between the two packages types.

__BEWARE__ : By deafault both installers don't install the wmData.dll needed for comunicating with the wavemeter through USB connection. This dll __must__ be the same as the one used by the software provided by the company (normally installed in sys32 or sysWOW64). If the wavemeter software is already installed the Wavemeter Service program will work without additional dlls. However if you're using this software for debug/testing/whaver_other_reason on a PC where the manufacturer software wasn't installed, you have go through a custom installation and add the dll wmData.dll.

 --->

## Proof of concept ##

Here's a small gif showing the data being read by another PC on the network using the python script given in the Example folder:

![GWSA_SHARED](https://github.com/mmazzanti/WavemeterService/blob/master/Icons/Shared_WL.gif)
The wavemeter Sharing App was installed on the PC connected to the wavemeter in the same network

## Wavemeter Sharing App

### Graphical User Interface (GUI)
![GWSA_GUI](https://github.com/mmazzanti/WavemeterService/blob/master/Icons/WavemeterSharingApp.png)

The software's interface is intuitive, but here's a brief explanation:
* **Start/Stop Buttons:** Control the initiation and cessation of data sharing via UDP.
* **Status Indicator (Green in the Image):** Provides real-time updates on the program's status. When actively sharing data, it turns green with "Running" text; otherwise, it's red with "Stopped" text.
* **Wavelengths:** Choose the channels whose wavelengths you want to share on the network.
* **Patterns to Share:** Select channels for pattern sharing. Caution: Limit pattern sharing, as JSON serialization can lead to high network usage.
* **Logging Area:** Displays user-based software activities.
* **Refresh Rate:** Set the time interval between two network packets. Align this with the sum of exposure times for the wavemeter's channels. Too frequent updates with long exposure times flood the network with redundant data, while infrequent updates with short exposure times introduce measurement delays.
* **Ratio:** Adjust the balance between network packets containing only wavelengths and those including wavelengths and patterns. A suggested range is 3-6 for balanced network usage (assuming a 50-100ms refresh time).
* **Network Settings:** Configure the network interface and delay time.

### User Settings
Except for network settings, all changes are automatically saved and recovered upon computer restart. Network settings can be saved using the dedicated "Save" button to prevent accidental adjustments.

### Taskbar Menu
When minimized or closed, the program continues running in the background. To fully terminate it, use the taskbar controls.

**Taskbar Controls:**
<!--- 
## Wavemeter Sharing App ##
### GUI ###
![GWSA_GUI](https://github.com/mmazzanti/WavemeterService/blob/master/Icons/WavemeterSharingApp.png)

The software is self eplanatory; however here's a short explanation :)!
* Start/stop buttons start and stop of sharing data on the UDP connection
* Status button (running, in green in the image) : Gives a live update on the status of the program. If sharing data the icon will be green (with running text) otherwise red (with stopped text)
* Wavelengths : channels which wavelength one wants to share on the network
* Patterns to share : channels which patterns one wants to share on the network. I strongly reccomend to limit the sharing of patterns as json serialisation might require intense network usage.
* Logging area : A text box for logging the activities of the sofware (mostly user based)
* Refresh : Wait time between two network packets. This should be set to similar value as the sum of the exposures of the various channels on the wavemeter. A small refresh rate compared to a longer exposure will spam the network with useless data that has yet to be updated. A big refresh rate compared to a shorter exposure time will reduce the network usage but involve some measurement delay.
* Ratio : Ratio between number of network packages containing only the wavelengths and packages containing wavelengths + patterns. I suggest to keep this to 3-6 to limit network usage (assuming 50-100ms refresh time).
* Network settings : Interface and delay time to be used on the network.

### User settings ###
All settings besides network ones are normally saved when changed and recovered in case of restart of the computer.
The Network settings can be saved using the save button. This to make it harder for people to screw up the important settings ;)

### Taskbar menu ###
When minimized or closed the program will still run in background, to terminate it fully use the taskbar controls.
Taskbar controls:
--->
<a>
  <img src="https://github.com/mmazzanti/WavemeterService/blob/master/Icons/WavemeterSharingAppMenu.png" width="30%" height="30%">
</a>

# Available clients #
* Python : see Example folder
* C++/Qt : [Wavemeter Client](https://github.com/wzl17/WMonitor)

Thank you for considering WavemeterService. We hope this repository simplifies the sharing of wavelength data from Toptica:tm:/Highfinesse:tm: wavelength meters for your needs.


<a href="https://www.buymeacoffee.com/mmazzanti" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

