import numpy as np
import matplotlib.pyplot as plt
from scipy.spatial import Voronoi, voronoi_plot_2d

width, height = 100, 100
num_seeds = 25

seeds = np.random.rand(num_seeds, 2) * [width, height]

vor = Voronoi(seeds)
fig, ax = plt.subplots()
voronoi_plot_2d(vor, ax=ax)
ax.set_xlim([0, width])
ax.set_ylim([0, height])
plt.show()
