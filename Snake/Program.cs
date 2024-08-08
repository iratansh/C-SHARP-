using Snake;
#nullable disable

Coord gridDimensions = new Coord(50, 20);
Coord snakePos = new Coord(10, 1);
Random rand = new Random();
Coord applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
int frameDelayMilliseconds = 100;
Direction movementDirection = Direction.Down;
List<Coord> snakePosHistory = new List<Coord>();
int score = 0;
int tailLength = 1;

while (true) {
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePos.ApplyMovementDirection(movementDirection);
    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);

            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord)) {
                Console.WriteLine("O");
            }
            else if (applePos.Equals(currentCoord)){
                Console.Write("@");
            }
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

    if (snakePos.Equals(applePos)) {
        tailLength++;
        score++;
        applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
    }
    else if (snakePos.X == 0 || snakePos.X == gridDimensions.X - 1 || snakePos.Y == 0 || snakePos.Y == gridDimensions.Y - 1 || snakePosHistory.Contains(snakePos)) {
        score = 0;
        tailLength = 1;
        snakePosHistory.Clear();
        snakePos = new Coord(10, 1);
        movementDirection = Direction.Down;
        continue;
    }

    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));
    if (snakePosHistory.Count > tailLength) {
        snakePosHistory.RemoveAt(0);
    }
    DateTime time = DateTime.Now;
    while ((DateTime.Now - time).Milliseconds < frameDelayMilliseconds) {
        if (Console.KeyAvailable) {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key) {
                case ConsoleKey.W:
                    if (movementDirection != Direction.Down) {
                        movementDirection = Direction.Up;
                    }
                    break;
                case ConsoleKey.S:
                    if (movementDirection != Direction.Up) {
                        movementDirection = Direction.Down;
                    }
                    break;
                case ConsoleKey.A:
                    if (movementDirection != Direction.Right) {
                        movementDirection = Direction.Left;
                    }
                    break;
                case ConsoleKey.D:
                    if (movementDirection != Direction.Left) {
                        movementDirection = Direction.Right;
                    }
                    break;
            }
        }
    }
}


