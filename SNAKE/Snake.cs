using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program

{

    static void Main()

    {
        //Settings console
        Console.WindowHeight = 16;

        Console.WindowWidth = 32;

        int screenwidth = Console.WindowWidth;

        int screenheight = Console.WindowHeight;

        
        Random randomnummer = new Random();

        //Shape of snake
        Pixel head = new Pixel();

        head.xPos = screenwidth / 2;

        head.yPos = screenheight / 2;

        head.ScreenColor = ConsoleColor.Red;

        string movement = "RIGHT";

        List<int> countPosition = new List<int>();

        int score = 0;

        //Pixel head1 = new Pixel();

        //head1.xPos = screenwidth / 2;

        //head1.yPos = screenheight / 2;

        //head1.ScreenColor = ConsoleColor.Red;



        //List<int> teljePositie = new List<int>();



        countPosition.Add(head.xPos);

        countPosition.Add(head.yPos);



        DateTime time = DateTime.Now;

        string obstacle = "*";

        //Obstacle settings
        int obstacleXpos = randomnummer.Next(1, screenwidth);

        int obstacleYpos = randomnummer.Next(1, screenheight);

        while (true)

        {

            Console.Clear();

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(obstacleXpos, obstacleYpos);

            Console.Write(obstacle);



            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");



            Console.ForegroundColor = ConsoleColor.White;

            // Drawing board
            //Top and bottom walls
            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }
            //Side walls
            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, screenheight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(screenwidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor =  /* ?? */;

            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("H");

            for (int i = 0; i < countPosition.Count(); i++)

            {

                Console.SetCursorPosition(countPosition[i], countPosition[i + 1]);

                Console.Write("■");

            }

            //Draw Snake

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");



            ConsoleKeyInfo info = Console.ReadKey();

            //Snake's movement

            switch (info.Key)

            {

                case ConsoleKey.UpArrow:
                {
                    movement = "UP";
                    break;
                }

                case ConsoleKey.DownArrow:
                {
                    movement = "DOWN";
                    break;
                }


                case ConsoleKey.LeftArrow:
                {
                    movement = "LEFT";
                    break;
                }

                case ConsoleKey.RightArrow:
                { 
                    movement = "RIGHT";
                    break;
                }

            }
            //Logic of movement
            if (movement == "UP")

                head.yPos--;

            if (movement == "DOWN")

                head.yPos++;

            if (movement == "LEFT")

                head.xPos--;

            if (movement == "RIGHT")

                head.xPos++;

            //Eating obstacle

            if (head.xPos == obstacleXpos /* ?? */ == obstacleYpos)

            {

                score++;

                obstacleXpos = randomnummer.Next(1, screenwidth);

                obstacleYpos = randomnummer.Next(1, screenheight);

            }

            countPosition.Insert(0, head.xPos);

            countPosition.Insert(1, head.yPos);

            countPosition.RemoveAt(countPosition.Count - 1);

            countPosition.RemoveAt(countPosition.Count - 1);

            //Collision with walls or with oneself

            if (head.xPos == 0 || head.xPos == screenwidth - 1 || head.yPos == 0 || head.yPos == screenheight - 1)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                Console.WriteLine("Game Over");

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                Console.WriteLine("Dein Score ist: " + score);

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                Environment.Exit(0);

            }

            for (int i = 0; i < countPosition.Count(); i += 2)

            {

                if (head.xPos == countPosition[i] && head.yPos == countPosition[i + 1])

                {

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                   //???

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                    Console.WriteLine("Your score is: " + score);

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(50);

        }

    }

}




