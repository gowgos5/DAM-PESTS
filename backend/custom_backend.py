from datetime import datetime
import paho.mqtt.client as mqtt
import os
import base64

broker = "VERNON-PC"
port = 1883

def base64_decode(img_code, date_time):
    image_64_decode = base64.decodebytes(img_code)
    image_result = open(date_time+".png", 'wb')
    image_result.write(image_64_decode)

def on_message(client, userdata, message):
    date_time = datetime.now().strftime("%d%m%Y_%H%M%S")
    base64_decode(message.payload, date_time)
    print("Processing image "+date_time+".png...")
    os.system("python custom_object.py "+date_time)

client = mqtt.Client("backend")
client.connect(broker,port)
client.subscribe("dam-pests/backend")
client.on_message = on_message
client.loop_forever()
