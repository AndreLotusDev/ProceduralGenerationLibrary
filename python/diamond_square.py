import numpy as np
import matplotlib.pyplot as plt

def diamond_square(size, scale):
    shape = (size, size)
    grid = np.zeros(shape)

    def square_step(x, y, length, scale):
        corners = grid[x:x+length, y:y+length]
        avg = np.sum(corners) / 4
        grid[x + length//2, y + length//2] = avg + np.random.uniform(-scale, scale)

    def diamond_step(x, y, length, scale):
        left = grid[x, y:y+length]
        top = grid[x:x+length, y]
        right = grid[x, y + length]
        bottom = grid[x + length, y]
        avg = np.sum([left, top, right, bottom]) / 4
        grid[x + length//2, y + length//2] = avg + np.random.uniform(-scale, scale)

    grid[0, 0] = np.random.uniform(-scale, scale)
    grid[0, -1] = np.random.uniform(-scale, scale)
    grid[-1, 0] = np.random.uniform(-scale, scale)
    grid[-1, -1] = np.random.uniform(-scale, scale)

    length = size - 1
    while length > 1:
        half = length // 2
        for x in range(0, size - 1, length):
            for y in range(0, size - 1, length):
                square
                square_step(x, y, length, scale)
        for x in range(0, size - 1, half):
            for y in range((x + half) % length, size - 1, length):
                diamond_step(x, y, half, scale)
        length //= 2
        scale *= 0.5
    return grid

size = 65
scale = 1.0
heightmap = diamond_square(size, scale)

plt.imshow(heightmap, cmap='gray')
plt.show()
