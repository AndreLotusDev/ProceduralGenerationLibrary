import numpy as np
import matplotlib.pyplot as plt
from random import randint


class Node:
    def __init__(self, x, y, width, height):
        self.x, self.y, self.width, self.height = x, y, width, height
        self.left = self.right = None


def bsp_split(node, min_size):
    if node.width < min_size * 2 or node.height < min_size * 2:
        return
    split_horizontal = node.width > node.height
    if split_horizontal:
        split_pos = randint(node.x + min_size, node.x + node.width - min_size)
        node.left = Node(node.x, node.y, split_pos - node.x, node.height)
        node.right = Node(split_pos, node.y, node.width - (split_pos - node.x), node.height)
    else:
        split_pos = randint(node.y + min_size, node.y + node.height - min_size)
        node.left = Node(node.x, node.y, node.width, split_pos - node.y)
        node.right = Node(node.x, split_pos, node.width, node.height - (split_pos - node.y))

    bsp_split(node.left, min_size)
    bsp_split(node.right, min_size)


def draw_bsp_tree(grid, node):
    if node.left is None and node.right is None:
        grid[node.y:node.y + node.height, node.x:node.x + node.width] = 1
    if node.left:
        draw_bsp_tree(grid, node.left)
    if node.right:
        draw_bsp_tree(grid, node.right)


width, height = 100, 100
grid = np.zeros((width, height))
root = Node(1, 1, width - 2, height - 2)

bsp_split(root, 8)
draw_bsp_tree(grid, root)

plt.imshow(grid, cmap='gray')
plt.show()
