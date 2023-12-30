import cv2
import os

image_folder = ['before']
output_folder = ['after']

# Output dimensions
width = int(1920/8)
height = int(1080/8)

# Number of frames to skip
skip_frames = 2


# Iterate through all the images in the folder
for i in range(len(image_folder)):
    
    # Create the output folder if it does not exist
    if not os.path.exists(output_folder[i]):
        os.makedirs(output_folder[i])
    # Clear the output folder if it already exists
    else:
        for filename in os.listdir(output_folder[i]):
            os.remove(os.path.join(output_folder[i], filename))
    current_frame = 0
    for filename in os.listdir(image_folder[i]):
        if not filename.endswith('.png'):
            continue
        if current_frame % skip_frames != 0:
            current_frame += 1
            continue

        print(filename)
        img = cv2.imread(os.path.join(image_folder[i],filename), cv2.IMREAD_UNCHANGED)
        if img is not None:
            img = cv2.resize(img, (width, height), interpolation=cv2.INTER_NEAREST)
            cv2.imwrite(os.path.join(output_folder[i], filename), img)
        
        current_frame += 1
