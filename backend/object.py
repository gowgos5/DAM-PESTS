from sys import argv
from imageai.Detection import ObjectDetection
import os
import paho.mqtt.client as paho
import base64

img_name = argv[1]
broker = "VERNON-PC"
port = 1883

# MQTT publish
def on_publish(client , userdata , result):
    print("Updated image sent to UI. \n")

# object recognition
def obj_recognition(img):
    execution_path = os.getcwd()

    detector = ObjectDetection()
    detector.setModelTypeAsRetinaNet()
    detector.setModelPath(os.path.join(execution_path , "resnet50_coco_best_v2.0.1.h5"))
    detector.loadModel()
    detections = detector.detectObjectsFromImage(input_image=os.path.join(execution_path,
    img+".png") , output_image_path=os.path.join(execution_path , img+"_pro.png") ,
    minimum_percentage_probability=50 , display_percentage_probability=False ,
    display_object_name=True)

    for eachObject in detections:
        print(eachObject["name"] , " : " , eachObject["percentage_probability"])

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

obj_recognition(img_name)
image_encoded = base64_encode(img_name+"_pro.png")

client = paho.Client("object")
client.on_publish = on_publish
client.connect(broker , port)
#client.publish("dam-pests/ui", img_name+"_pro.png" , 1, False)
client.publish("dam-pests/ui", image_encoded , 1, False)
client.loop(1)
client.disconnect()
