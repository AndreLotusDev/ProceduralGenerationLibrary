import pygame
import random
import math

# Define constants for the world size and tile size
WORLD_SIZE = (800, 600)
TILE_SIZE = 10

# Define constants for the biomes
BIOMES = {
    "water": (0, 0, 255),
    "grass": (0, 255, 0),
    "desert": (255, 255, 0),
    "forest": (0, 100, 0),
}

# Initialize the Pygame display
pygame.init()
screen = pygame.display.set_mode(WORLD_SIZE)

# Define a function to check if a tile is within the world bounds
def is_within_bounds(x, y):
    return x >= 0 and x < len(world[0]) and y >= 0 and y < len(world)

# Define a function to reset the world
def reset_world():
    global world
    world = [["water" for x in range(WORLD_SIZE[0] // TILE_SIZE)] for y in range(WORLD_SIZE[1] // TILE_SIZE)]

# Define a function to generate an island
def generate_island():
    # Generate a random location and radius for the island
    center = (random.randint(0, WORLD_SIZE[0] // TILE_SIZE), random.randint(0, WORLD_SIZE[1] // TILE_SIZE))
    radius = random.randint(10, 20)

    # Generate a random biome for the island
    biome = random.choice(list(BIOMES.keys()))

    # Fill the area within the island radius with the chosen biome
    for y in range(center[1] - radius, center[1] + radius):
        for x in range(center[0] - radius, center[0] + radius):
            if is_within_bounds(x, y) and ((x - center[0]) ** 2 + (y - center[1]) ** 2) <= radius ** 2:
                world[y][x] = biome

# Define a function to connect the islands with water
def connect_islands():
    for y in range(len(world)):
        for x in range(len(world[0])):
            if world[y][x] != "water":
                # Find the closest island
                min_distance = float("inf")
                closest_island = None
                for ny in range(len(world)):
                    for nx in range(len(world[0])):
                        if world[ny][nx] != "water":
                            distance = math.sqrt((nx - x) ** 2 + (ny - y) ** 2)
                            if distance < min_distance:
                                min_distance = distance
                                closest_island = world[ny][nx]

                # Connect the tile to the closest island
                connected = False
                for dy in range(-1, 2):
                    for dx in range(-1, 2):
                        if dx != 0 or dy != 0:
                            nx = x + dx
                            ny = y + dy
                            if is_within_bounds(nx, ny) and world[ny][nx] == "water":
                                world[ny][nx] = closest_island

# Generate the islands
reset_world()
for i in range(5):
    generate_island()

# Connect the islands with water
connect_islands()

# Define the game loop
running = True
while running:
    # Handle events
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_r:
                # Regenerate the islands and connections
                reset_world()
                for i in range(5):
                    generate_island()
                connect_islands()

    # Draw the world
    for y in range(len(world)):
        for x in range(len(world[0])):
            pygame.draw.rect(screen, BIOMES[world[y][x]], (x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE))

    # Update the screen
    pygame.display.flip()
