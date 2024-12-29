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

![image](https://github.com/user-attachments/assets/3d9aac13-7d13-407a-a909-d2eb3956b97b)
![image](https://github.com/user-attachments/assets/6d387d3e-fde9-499e-a6ba-f375af34e226)
![image](https://github.com/user-attachments/assets/d19f882c-d31d-4d9c-a236-c41116e1e93e)

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or higher installed on your system.

### Running the Game

1. Clone this repository:
   ```bash
   git clone [<repository_url>](https://github.com/tuna-b/CSharp-Snake.git)
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

