from keras.models import load_model
import sys
import numpy as np
import glob
import os

import airsim

if ('../PythonClient/' not in sys.path):
    sys.path.insert(0, '../PythonClient/')

#from AirSimClient import *

# << Set this to the path of the model >>
# If None, then the model with the lowest validation loss from training will be used
MODEL_PATH = None

if (MODEL_PATH == None):
    models = glob.glob('model2\models\*.h5')
    print("** ", models)
    best_model = max(models, key=os.path.getctime)
    MODEL_PATH = best_model

print('Using model {0} for testing.'.format(MODEL_PATH))

model = load_model(MODEL_PATH)
client = airsim.CarClient()
client.confirmConnection()
client.enableApiControl(True)
car_controls = airsim.CarControls()
client.reset()
print('Connection established!')

# 차량위치 변경
position = airsim.Vector3r(39, 94, 9.9)
heading = airsim.utils.to_quaternion(0, 0, 2.5)
pose = airsim.Pose(position, heading)
client.simSetVehiclePose(pose, True)

car_controls.steering = 0
car_controls.throttle = 0
car_controls.brake = 0

image_buf = np.zeros((1, 59, 255, 3))
state_buf = np.zeros((1, 4))


def get_image():
    image_response = client.simGetImages([airsim.ImageRequest("0", airsim.ImageType.Scene, False, False)])[0]
    image1d = np.fromstring(image_response.image_data_uint8, dtype=np.uint8)
    image_rgba = image1d.reshape(image_response.height, image_response.width, 3)

    return image_rgba[76:135, 0:255, 0:3].astype(float)


while (True):
    car_state = client.getCarState()

    if (car_state.speed < 3):
        car_controls.throttle = 1
    else:
        car_controls.throttle = 0.0

    image_buf[0] = get_image()
    state_buf[0] = np.array([car_controls.steering, car_controls.throttle, car_controls.brake, car_state.speed])
    model_output = model.predict([image_buf, state_buf])
    car_controls.steering = round(-0.05 * float(model_output[0][0]), 2)
    # print('model_ouput: ', (model_output[0][0]))
    print('Sending steering = {0}, throttle = {1}'.format(car_controls.steering, car_controls.throttle))

    client.setCarControls(car_controls)