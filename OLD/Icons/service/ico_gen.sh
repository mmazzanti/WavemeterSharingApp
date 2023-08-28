#!/bin/bash
#for size in 16 32 48 128 256; do
#	    inkscape -z -e $size.png -w $size -h $size WM_service_Icon.svg >/dev/null 2>/dev/null
#    done
#    convert 16.png 32.png 48.png 128.png 256.png -colors 256 icon.ico
convert WM_service_Icon.svg -define icon:auto-resize=256,64,48,32,16 icon.ico
