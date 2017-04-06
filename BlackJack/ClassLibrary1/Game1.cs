using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    partial class Game
    {
        public void PlayerStart()
        {
            bool raz = false;
            for (int i = 0; i < 2;)  //two card are dealt
            {
                int random = r.Next(0, 52);

                if (!array[random].isUsed)
                {
                    _sumplayer += (int)array[random].card;
                    Console.WriteLine($"{array[random].card} - {array[random].suit}");
                    array[random].isUsed = true;
                    i++;
                }
            }            
            if (_sumplayer == 22)
            {
                Console.WriteLine("You have BlackJack!!!");
                if (_sumcomputer == 0)
                {
                    Console.WriteLine("Computer's turn");
                    Console.WriteLine(new string('-', 100));
                    ComputerStart();
                    raz = true;
                    // Calling player's game mathod 
                } 
                else
                {
                    Console.WriteLine(new string('-', 100));
                    Consider();
                    raz = true;
                    //Вызывается метод подсчета
                }
            }

            while(!raz)
            {
                Console.WriteLine("Yet or that's enough?");
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.KeyChar == 13)
                {
                    int index = r.Next(0, 52);
                    bool p = false;
                    while (!p)
                    {
                        if (!array[index].isUsed)
                        {
                            _sumplayer += (int)array[index].card;
                            Console.WriteLine($"{array[index].card} - {array[index].suit} ");
                            array[index].isUsed = true;
                            p = true;
                        }
                    }
                } 
                else
                {
                    Console.CursorLeft = 0;                   
                    Console.WriteLine($"You have {_sumplayer} points");                    
                    break;
                }          
            }



            if (_sumcomputer == 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("Computer's turn");
                ComputerStart();

            } 
            else
            {
                Console.WriteLine(new string('-', 100));
                Consider();
            }
       }
    }           
 }

    

