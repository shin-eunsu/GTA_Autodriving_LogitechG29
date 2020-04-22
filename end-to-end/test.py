import cv2
print(cv2.__version__)
# src = cv2.imread("D:\GTA_DATA1\data_raw\200421_111433\images\200421_111433_30.jpg", cv2.IMREAD_COLOR)
src = cv2.imread("C:/G29_Autodriving/end-to-end/test_img.jpg", cv2.IMREAD_COLOR)
cv2.imshow("src", src)
cv2.waitKey(0)
cv2.destroyAllWindows()