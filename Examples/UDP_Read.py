import socket
import json
import matplotlib.pyplot as plt
import numpy as np
import time

# IP address of the computer listening for the wavemeter sharing app
# Check that the wavemeter PC and the listening PC are on the same network!
UDP_IP = "Put here your IP address"

# Port for the comunication with the wavemeter sharing app.
# Default 9897
UDP_PORT = 9897

# Bind socket for connection
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # UDP
sock.bind((UDP_IP, UDP_PORT))

# Channel to show
ChToShow = 1

# Prepare pattern plot
# Beware, if no pattern is shown this will appear as an empty plot
plt.ion()
fig = plt.figure()
ax = fig.add_subplot(111)

# Start listening thread
run = 0
while True:
    # Prepare buffer
    data, addr = sock.recvfrom(50*1024) # buffer size is 1024 bytes

    # load json data received from the wavemeter
    WM_DATA = json.loads(data) 

    # Show pattern of channel 
    y = WM_DATA[ChToShow]["PatternData"]

    # If in that data packet no pattern was received skip the update of the plot
    if y != None and len(y)>0:
        x = np.linspace(1, len(y),len(y))
        if (run == 0):
            line1, = ax.plot(x, y, 'b-')
            #plt.show()
        run = 1
        
        # Update plot
        line1.set_ydata(y)
        fig.canvas.draw()

        fig.canvas.flush_events()
        
    # Print wavelength of channel <ChToShow> 
    print("Frequency: %s" % WM_DATA[ChToShow]["Frequency"])
