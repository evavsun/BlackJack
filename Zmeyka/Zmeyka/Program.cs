using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeyka
{
    struct Coord
    {
        public int x, y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Global variables
            Coord[] snake = new Coord[100];
            int[,] pole = new int[Console.WindowWidth, Console.WindowHeight];// 1-apple, 2- orange; 100 -стена
            int count = 3;
            int dx = 1, dy = 0;
            int Score = 0;
            Random rand = new Random();
            ConsoleKeyInfo Key = new ConsoleKeyInfo();

            // Initialize
            snake[0].x = Console.WindowWidth / 2;
            snake[0].y = Console.WindowHeight / 2;
            snake[1].x = snake[0].x - 1;
            snake[1].y = snake[0].y;
            snake[2].x = snake[1].x - 1;
            snake[2].y = snake[1].y;

            pole[10, 5] = 1;
            pole[14, 6] = 1;
            pole[40, 25] = 1;
            pole[20, 17] = 2;
            pole[10, 15] = 100;
            //Draw Pole
            for (int i = 0; i < Console.WindowWidth; i++)
                for (int j = 0; j < Console.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    switch (pole[i, j])
                    {
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("G");
                            break;
                        case 100:
                            Console.Write("|");
                            break;
                    }
                }

            //Main Loop
            while ((Key.Key != ConsoleKey.Escape))
            {
                //Drawing

                for (int i = 0; i < count; i++)
                {
                    Console.SetCursorPosition(snake[i].x, snake[i].y);
                    Console.Write("*");
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Score: {0}", Score);
                System.Threading.Thread.Sleep(100);

                //Delete tail
                Console.SetCursorPosition(snake[count - 1].x, snake[count - 1].y);
                Console.WriteLine(" ");

                //Snake moving
                for (int i = count - 1; i > 0; i--)
                {
                    snake[i] = snake[i - 1];
                }
                if (Console.KeyAvailable) Key = Console.ReadKey();
                switch (Key.Key)
                {
                    case ConsoleKey.RightArrow:
                        dx = 1; dy = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        dx = -1; dy = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        dx = 0; dy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        dx = 0; dy = 1;
                        break;
                }
                snake[0].x = snake[0].x + dx;
                snake[0].y = snake[0].y + dy;

                //end of window
                if (snake[0].x >= Console.WindowWidth && dx == 1) snake[0].x = 0;
                if (snake[0].x <= Console.WindowLeft && dx == -1) snake[0].x = Console.WindowWidth - 1;
                if (snake[0].y >= Console.WindowHeight && dy == 1) snake[0].y = 0;
                if (snake[0].y <= Console.WindowTop && dy == -1) snake[0].y = Console.WindowHeight - 1;

                // pole objects
                if (pole[snake[0].x, snake[0].y] == 1) { Score = Score + 10; pole[snake[0].x, snake[0].y] = 0; count++; };
                if (pole[snake[0].x, snake[0].y] == 2)
                {
                    int a, b;
                    count++;
                    Score = Score + 50; pole[snake[0].x, snake[0].y] = 0;
                    a = rand.Next(Console.WindowWidth - 1);
                    b = rand.Next(Console.WindowHeight - 1);
                    pole[a, b] = 2;
                    Console.SetCursorPosition(a, b);
                    Console.Write("G");
                };
                if (pole[snake[0].x, snake[0].y] == 100)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.Write("Game over");
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
