import numpy as np
import matplotlib.pyplot as plt

def iterate_automata(grid):
    new_grid = grid.copy()
    for x in range(grid.shape[0]):
        for y in range(grid.shape[1]):
            alive_neighbors = np.sum(grid[x-1:x+2, y-1:y+2]) - grid[x, y]
            if grid[x, y] == 1 and (alive_neighbors < 2 or alive_neighbors > 3):
                new_grid[x, y] = 0
            elif grid[x, y] == 0 and alive_neighbors == 3:
                new_grid[x, y] = 1
    return new_grid

width, height = 100, 100
grid = np.random.choice([0, 1], size=(width, height), p=[0.5, 0.5])

for _ in range(10):
    grid = iterate_automata(grid)

plt.imshow(grid, cmap='gray')
plt.show()
