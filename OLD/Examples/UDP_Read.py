import socket
import json
import matplotlib.pyplot as plt
import numpy as np
import time

UDP_IP = "10.10.12.205"
UDP_PORT = 9898 
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # UDP
sock.bind((UDP_IP, UDP_PORT))
plt.ion()
fig = plt.figure()
ax = fig.add_subplot(111)

run = 0
while True:
    data, addr = sock.recvfrom(50*1024) # buffer size is 1024 bytes
    WM_DATA = json.loads(data) 
    y = WM_DATA[6]["PatternData"]
    x = np.linspace(1, len(y),len(y))
    if (run == 0):
        line1, = ax.plot(x, y, 'b-')
        #plt.show()
    run = 1
    time.sleep(0.1)
    line1.set_ydata(y)
    fig.canvas.draw()
    fig.canvas.flush_events()
    print("Frequency: %s" % WM_DATA[6]["Frequency"])
