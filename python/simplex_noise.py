import noise
import numpy as np
import matplotlib.pyplot as plt

width, height = 100, 100
scale = 0.1
noise_map = np.zeros((width, height))

for x in range(width):
    for y in range(height):
        noise_map[x][y] = noise.pnoise2(x * scale, y * scale)

plt.imshow(noise_map, cmap='gray')
plt.show()
