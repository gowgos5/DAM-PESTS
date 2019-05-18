from sys import argv
import paho.mqtt.client as paho
import base64

img_name = argv[1]
broker = "VERNON-PC"
port = 1883

# base64 encoding
def base64_encode(img):
    # Get the image
    image = open(img, 'rb')
    image_read = image.read()

    # Get the Byte-Version of the image
    image_64_encode = base64.b64encode(image_read)

    # Convert it to a readable utf-8 code (a string)
    image_encoded = image_64_encode.decode('utf-8')
    return image_encoded

image_encoded = base64_encode(img_name+".png")

client = paho.Client("object")
client.connect(broker , port)
client.publish("dam-pests/backend", image_encoded , 1, False)
print("backend activated")
client.loop(1)
client.disconnect()
