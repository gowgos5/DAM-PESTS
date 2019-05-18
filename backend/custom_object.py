from sys import argv
from imageai.Prediction.Custom import CustomImagePrediction
import os
import paho.mqtt.client as paho
import base64
from PIL import Image, ImageDraw, ImageFont

img_name = argv[1]
broker = "VERNON-PC"
port = 1883
(x, y) = (25, 25)
size = 120;

# MQTT publish
def on_publish(client , userdata , result):
    print("Updated image sent to UI. \n")

# object prediction
def obj_prediction(img):
    execution_path = os.getcwd()

    prediction = CustomImagePrediction()
    prediction.setModelTypeAsResNet()
    prediction.setModelPath(os.path.join(execution_path, "rat_model.h5"))
    prediction.setJsonPath(os.path.join(execution_path, "model_class.json"))
    prediction.loadModel(num_objects=2, prediction_speed="fastest")

    predictions, probabilities = prediction.predictImage(os.path.join(execution_path, img+".png"), result_count=2)
    
    max_prediction = ""
    max_probability = -1.00
    print("\n=================================");
    for eachPrediction, eachProbability in zip(predictions, probabilities):
        if (max_probability < float(eachProbability)):
            max_prediction = eachPrediction
            max_probability = float(eachProbability)
            
        print(eachPrediction + " : " + eachProbability)
    print("=================================\n");

    # create Image object with the input image
    image = Image.open(img+".png")
 
    # initialise the drawing context with the image object as background 
    draw = ImageDraw.Draw(image)

    # create font object with the font file and specify desired size
    font = ImageFont.truetype("Roboto-Black.ttf", size=size, encoding="unic")
    colour = "rgb(255, 255, 255)"
     
    # draw the message on the background
    draw.rectangle(((0, 0), (1500, 160)), outline="rgb(0, 0, 0)", fill="rgb(0, 0, 0)")
    draw.text((x, y), max_prediction+ ": " + str(max_probability),
              fill=colour, font=font)
     
    # save the edited image
    image.save(img+"_pro.png")
    print("Generated "+img_name+"_pro.png")

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

obj_prediction(img_name)
image_encoded = base64_encode(img_name+"_pro.png")

client = paho.Client("object")
client.on_publish = on_publish
client.connect(broker , port)
client.publish("dam-pests/ui", img_name+"_pro.png" , 1, False)
#client.publish("dam-pests/ui", image_encoded , 1, False)
client.loop(1)
client.disconnect()
