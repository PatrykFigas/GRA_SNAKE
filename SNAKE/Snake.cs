class Program
{
    static void Main()
    {
        //Settings console
        Console.WindowWidth = 100;  // Szerokość okna konsoli
        Console.WindowHeight = 40;  // Wysokość okna konsoli

        Console.BufferWidth = 100;  // Szerokość bufora
        Console.BufferHeight = 40;  // Wysokość bufora
        int screenwidth = Console.WindowWidth;
        int screenheight = Console.WindowHeight;

        //// Ustawienie minimalnej wielkości okna konsoli
        //Console.WindowHeight = Math.Max(16, screenheight); // Upewnij się, że wysokość nie jest mniejsza niż 16
        //Console.WindowWidth = Math.Max(32, screenwidth); // Upewnij się, że szerokość nie jest mniejsza niż 32


        Random random = new Random();

        // Initial Snake setup
        Pixel head = new Pixel(screenwidth / 2, screenheight / 2, ConsoleColor.Green, "■");
        List<Pixel> snake = new List<Pixel> { head };
        string movement = "RIGHT";

        int score = 0;

        // Create obstacles
        List<Obstacle> obstacles = new List<Obstacle>();
        for (int i = 0; i < 3; i++) // Create 3 obstacles
        {
            obstacles.Add(new Obstacle(random.Next(1, screenwidth - 1), random.Next(1, screenheight - 1), ConsoleColor.Cyan, "*"));
        }

        DateTime time = DateTime.Now;

        while (true)
        {
            Console.Clear();

            // Draw obstacles
            foreach (var obstacle in obstacles)
            {
                obstacle.draw();
            }

            // Draw snake
            foreach (var pixel in snake)
            {
                pixel.Draw();
            }

            // Draw border
            for (int i = 1; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("■");
            }
            for (int i = 1; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }

            Console.SetCursorPosition(0, screenheight-5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Score: " + score);

            // Control snake movement
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true); // true, aby nie wyświetlać naciśniętego klawisza

                if (movement == "RIGHT" && info.Key == ConsoleKey.LeftArrow) return;
                if (movement == "LEFT" && info.Key == ConsoleKey.RightArrow) return;
                if (movement == "UP" && info.Key == ConsoleKey.DownArrow) return;
                if (movement == "DOWN" && info.Key == ConsoleKey.UpArrow) return;

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        movement = "UP";
                        break;
                    case ConsoleKey.DownArrow:
                        movement = "DOWN";
                        break;
                    case ConsoleKey.LeftArrow:
                        movement = "LEFT";
                        break;
                    case ConsoleKey.RightArrow:
                        movement = "RIGHT";
                        break;
                }
            }


            // Move snake
            Pixel newHead = new Pixel(snake[0].xPos, snake[0].yPos, ConsoleColor.Green, "■");

            switch (movement)
            {
                case "UP":
                    newHead.yPos--;
                    break;
                case "DOWN":
                    newHead.yPos++;
                    break;
                case "LEFT":
                    newHead.xPos--;
                    break;
                case "RIGHT":
                    newHead.xPos++;
                    break;
            }

            // Add new head to the snake
            snake.Insert(0, newHead);

            // Check for collision with the wall
            if (newHead.xPos == 0 || newHead.xPos == screenwidth - 1 || newHead.yPos == 0 || newHead.yPos == screenheight - 1)
            {
                GameOver(score);
                return;
            }

            // Check for collision with body
            for (int i = 1; i < snake.Count; i++)
            {
                if (newHead.xPos == snake[i].xPos && newHead.yPos == snake[i].yPos)
                {
                    GameOver(score);
                    return;
                }
            }

            // Check for collision with obstacles
            foreach (var obstacle in obstacles)
            {
                if (newHead.xPos == obstacle.Xpos && newHead.yPos == obstacle.Ypos)
                {
                    score++;
                    return;
                }
            }

            // Eating the "food" (obstacle for now)
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (newHead.xPos == obstacles[i].Xpos && newHead.yPos == obstacles[i].Ypos)
                {
                    score++;
                    obstacles.RemoveAt(i); // Remove the eaten obstacle
                    obstacles.Add(new Obstacle(random.Next(1, screenwidth - 1), random.Next(1, screenheight - 1), ConsoleColor.Cyan, "*"));
                    break;
                }
            }


            // Remove tail
            snake.RemoveAt(snake.Count - 1);

            // Sleep to make the game playable
            Thread.Sleep(100);
        }
    }

    static void GameOver(int score)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(10, 8);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(10, 9);
        Console.WriteLine("Score: " + score);
        Console.SetCursorPosition(10, 10);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        Environment.Exit(0);  // Exit the game
    }
}






