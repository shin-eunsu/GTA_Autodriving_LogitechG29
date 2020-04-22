from keras.models import load_model
import sys
import numpy as np
import glob
import os
import cv2

# << Set this to the path of the model >>
# If None, then the model with the lowest validation loss from training will be used
MODEL_PATH = None
if (MODEL_PATH == None):
    models = glob.glob('D:/GTA_DATA1/model_GTA_holein1/models/*.h5')
    best_model = max(models, key=os.path.getctime)
    MODEL_PATH = best_model
model = load_model(MODEL_PATH)

Steering = 0
Accelerator = 0
Brake = 0

img = cv2.imread(sys.argv[1], cv2.IMREAD_COLOR)
crop_img = img[80:148, 2:198]

image_buf = np.zeros((1, 68, 196, 3))
state_buf = np.zeros((1, 3))

image_buf[0] = crop_img
state_buf[0] = np.array([Steering, Accelerator, Brake])
model_output = model.predict([image_buf, state_buf])
print("result: ", model_output[0][0])

