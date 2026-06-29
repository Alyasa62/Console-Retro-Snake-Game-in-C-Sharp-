using Snake_Bites;

Coord gridDimentions = new Coord(70, 20);
Coord snakePosition = new Coord(10, 1);
Random rand = new Random();
Coord applePosition = new Coord(rand.Next(1, gridDimentions.X - 1), rand.Next(1, gridDimentions.Y - 1));
int frameDelayMilli = 100;
Direction movementDirection = Direction.Down;
List<Coord> snakePositionHistory = new List<Coord>();
int tailLength = 1;

while (true)
{
    Console.Clear();
    snakePosition.applyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimentions.Y; y++)
    {
        for (int x = 0; x < gridDimentions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);
            if (snakePosition.Equals(currentCoord))
            {
                Console.Write("■");

            }
            else if (applePosition.Equals(currentCoord))
                Console.Write("█");
            else if (x == 0 || y == 0 || x == gridDimentions.X - 1 || y == gridDimentions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");

        }
        Console.WriteLine();

    }

    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).Milliseconds < frameDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left; 
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;

            }
    }
}
}