using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibrary1
{
    public partial class Game
    {        
        Random r = new Random();
        Card[] array = new Card[52];
        int _sumcomputer = 0;
        int _sumplayer = 0;
        public Game() // Initialize all cards
        {
            int index = 0;           
            foreach (SuitName suits in Enum.GetValues(typeof(SuitName)))
            {
                foreach(CardName cards in Enum.GetValues(typeof(CardName)))
                {
                    array[index] = new Card() { suit = suits, card = cards };
                    index++;
                }
            }

            CheckWhoWillFirst();
        }

        public void CheckWhoWillFirst()
        {
            bool who = false;
            while (!who)
            {
                CardName player = (CardName)r.Next(0,52);
                CardName computer = (CardName)r.Next(0,52);

                if (player > computer)
                {
                    //начнет игрок
                    Console.WriteLine(new string('-', 100));
                    Console.WriteLine("Player START");
                    PlayerStart();
                    who = true;
                }
                if (computer > player)
                {
                    Console.WriteLine(new string('-', 100));
                    Console.WriteLine("Computer START");
                    ComputerStart();
                    who = true;
                    //начнет компьютер
                } 
                if (computer==player)
                {                   
                    Console.WriteLine("The cards are equal, try again");
                    Console.WriteLine(new string('-', 100));
                    
                }
            }
        }  
        
        public void ComputerStart()
        {
            bool raz = false;
            for (int i = 0; i < 2; )  //two card are dealt
            {
                int random = r.Next(0,52);

                if (!array[random].isUsed)
                {                    
                    _sumcomputer += (int)array[random].card;
                    Console.WriteLine($"{array[random].card} - {array[random].suit} ");
                    array[random].isUsed = true;                   
                    i++;
                }
                
            }

            if (_sumcomputer==22)
            {
                Console.WriteLine("Computer has BlackJack!!!");
                if (_sumplayer==0)
                {
                    Console.WriteLine("Your try)");
                    PlayerStart();
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
                if (_sumcomputer <= 18)
                {
                    int index = r.Next(0, 52);

                    if (!array[index].isUsed)
                    {
                        _sumcomputer += (int)array[index].card;
                        Console.WriteLine($"{array[index].card} - {array[index].suit} ");
                        array[index].isUsed = true;

                    }
                }
                if (_sumcomputer>18&&_sumcomputer<=21)
                {
                    Console.WriteLine("Enough!");
                    Console.WriteLine($"Computer have {_sumcomputer} points");                                     
                    raz = true;
                }
                if (_sumcomputer>21)
                {
                     Console.WriteLine("Enough!");
                     raz = true;
                     Console.WriteLine($"Computer have {_sumcomputer} points");
                }               

            }

            if (_sumplayer == 0)
            {
                Console.WriteLine("Your try");
                PlayerStart();
                // Calling player's game mathod 
            }
            else
            {
                Console.WriteLine(new string('-', 100));
                Consider();
                //Вызывается метод подсчета
            }
        }

        public void Consider()
        {
           if (_sumcomputer>_sumplayer&&_sumcomputer<=21)
            {
                Console.WriteLine("Computer won!!!");
            }
           else if (_sumplayer>_sumcomputer&&_sumplayer<=21)
            {
                Console.WriteLine("Player won");
            }
           else if (_sumcomputer<=21&&_sumplayer>21)
            {
                Console.WriteLine("Computer won");
            }
           else if (_sumplayer<=21&&_sumcomputer>21)
            {
                Console.WriteLine("Player won");
            }
           else if (_sumcomputer==_sumplayer&&_sumplayer<=21)
            {
                Console.WriteLine("Dead head");
            }
           else if (_sumplayer>21&&_sumcomputer>21)
            {
                Console.WriteLine("Loosers");
            }

        } 
    }
}
