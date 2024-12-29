# Snake Game in C#

This is a console-based Snake game written in C#. It provides a simple and interactive gaming experience directly in the terminal.

## Features

- **Classic Snake Mechanics**: Control the snake to eat food and grow while avoiding collisions.
- **Dynamic Board**: The game board updates with the snake's movements, food placement, and borders.
- **Collision Detection**: Game ends when the snake collides with the border or itself.
- **Score Tracking**: Your final score is displayed at the end of the game based on the snake's length.

## Gameplay

- Use the arrow keys to move the snake:
  - **Left Arrow**: Move left
  - **Right Arrow**: Move right
  - **Up Arrow**: Move up
  - **Down Arrow**: Move down
- The game ends if the snake runs into itself or the border.

## Screenshots

<img src="https://github.com/user-attachments/assets/c5fe413e-5a6b-49aa-8aba-923339927af4" alt="Image 1" width="200" height="200">
<br>
<img src="https://github.com/user-attachments/assets/fdd2c343-45b5-49f0-bfcc-128b6fe35028" alt="Image 2" height="200" width="200">
<br>
<img src="https://github.com/user-attachments/assets/3ba0150a-0065-4bc0-8885-a8cfe7f87ee4" alt="Image 3" width="200" height="200">


## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or higher installed on your system.

### Running the Game

1. Clone this repository:
   ```bash
   git clone <https://github.com/tuna-b/CSharp-Snake.git>
   cd <repository_directory>
   ```
2. Build the project using the .NET CLI:
   ```bash
   dotnet build
   ```
3. Run the game:
   ```bash
   dotnet run
   ```

### How It Works

The game initializes a 10x10 board where:
- Borders are represented as `#`.
- The snake is represented as `~`.
- Food is represented as `o`.

The snake grows longer when it eats food and the game continues until a collision occurs.

## Project Structure

- **Program.cs**: Contains the entry point for the game.
- **Board.cs**: Manages the game board, including initialization and updates.
- **Coord.cs**: Defines the coordinate system for the board and categorizes cells as food, snake, empty, or border.
- **Snake.cs**: Represents the snake's state, including its head and body.
- **GameLogic.cs**: Implements the core game logic, including food generation, snake movement, and collision detection.

## Customization

You can modify the game by:
- Changing the board dimensions in the `Board` constructor in `Program.cs`.
- Adjusting the snake's initial position.
- Modifying the snake's movement speed by changing the `Thread.Sleep` duration in `GameLogic.cs`.


## Acknowledgments

Inspired by the classic Snake game.

---

Enjoy playing the game!

