# Zombie Dice Game

A simple C# implementation of the **Zombie Dice** game, where players roll dice to collect brains while avoiding shotguns. The game is played in turns, with two players rolling dice from a cup, collecting brains, avoiding shotguns, and earning points. The first player to accumulate 13 brains wins.

## Features

- Two-player gameplay.
- Different types of dice (Green, Yellow, Red, and Hottie), each with different odds of getting brains, shotguns, and footprints.
- Players can roll dice, decide whether to roll again, and end their turn.
- The game ends when one player accumulates 13 brains.

## Game Rules

1. Players take turns rolling dice.
2. On a turn, a player rolls three dice from the cup.
3. Each die can land on:
    - **Brain** (adds to the player's score)
    - **Shotgun** (if a player gets 3 shotguns, they lose their turn)
    - **Footprint** (players must roll again for these dice)
4. The first player to reach 13 brains wins the game.

## Installation

To run the game, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/zombiedice.git
