from datetime import datetime
from picamera import PiCamera
from time import sleep

camera = PiCamera()

# camera live preview
# only applicable if preview is upside-down
# camera.rotation = 180
camera.resolution = (1024, 768)
camera.start_preview()
sleep(10)
camera.stop_preview()

# camera still pictures
# take 5 pictures in one go
for i in range(5):
    date_time = datetime.now().strftime("%d%m%Y_%H%M%S")
    camera.capture("/home/pi/Desktop/"+date_time+".png...", resize=(320, 240))
    sleep(.5)
