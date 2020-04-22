import airsim
import numpy as np
import cv2

src = cv2.imread("C:/G29_Autodriving/end-to-end/test_img.jpg", cv2.IMREAD_COLOR)

client = airsim.CarClient()
client.confirmConnection()

image_response = client.simGetImages([airsim.ImageRequest("0", airsim.ImageType.Scene, False, False)])[0]
image1d = np.fromstring(image_response.image_data_uint8, dtype=np.uint8)
image_rgba = image1d.reshape(image_response.height, image_response.width, 3)

print(image_rgba.shape)
print(src.shape)