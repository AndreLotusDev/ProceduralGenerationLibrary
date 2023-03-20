import numpy as np
import matplotlib.pyplot as plt
import random

width, height = 100, 100
steps = 10000
grid = np.zeros((width, height))
x, y = width // 2, height // 2

for _ in range(steps):
    grid[x, y] = 1
    dx, dy = random.choice([(0, 1), (1, 0), (0, -1), (-1, 0)])
    x = (x + dx) % width
    y = (y + dy) % height

plt.imshow(grid, cmap='gray')
plt.show()
