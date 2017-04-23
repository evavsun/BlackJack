using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


public class Game
{
    Random r = new Random();
    Card[] array = new Card[52];
    int _sumcomputer = 0; //computer's points
    int _sumplayer = 0; //user's points
    const int _blackJackPoints = 21;
    public Game() // Initialize all cards
    {
        int index = 0;
        foreach (SuitName suits in Enum.GetValues(typeof(SuitName)))
        {
            foreach (CardName cards in Enum.GetValues(typeof(CardName)))
            {
                array[index] = new Card() { Suit = suits, Cards = cards };
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
            CardName player = (CardName)r.Next(0, 52);
            CardName computer = (CardName)r.Next(0, 52);

            if (player > computer)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("Player START");
                PlayerStart(); //users's game
                who = true;
            }
            if (computer > player)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("Computer START");
                ComputerStart(); //computer's game
                who = true;
            }
            if (computer == player)
            {
                Console.WriteLine("The cards are equal, try again");
                Console.WriteLine(new string('-', 100));
            }
        }
    }


    public int TwoFirstCards()
    {
        for (int i = 0; i < 2;)  //two cards are dealt
        {
            int random = r.Next(0, 52);

            if (!array[random].IsUsed)
            {
                _sumcomputer += (int)array[random].Cards;
                Console.WriteLine($"{array[random].Cards} - {array[random].Suit} ");
                array[random].IsUsed = true;
                i++;
            }
        }
        return _sumcomputer;
    }
    public void ComputerStart()
    {
        bool raz = false;
        _sumcomputer = TwoFirstCards();

        if (_sumcomputer == 22) //Dropped 2 aces
        {
            Console.WriteLine("Computer has BlackJack!!!");
            if (_sumplayer == 0)
            {
                Console.WriteLine("Your try)");
                PlayerStart();
                raz = true;
                // Calling player's game mathod 
            } else
            {
                Console.WriteLine(new string('-', 100));
                Consider(); //Count who won
                raz = true;

            }
        }

        while (!raz)
        {
            Console.WriteLine("Yet or that's enough?");
            if (_sumcomputer <= 18)
            {
                int index = r.Next(0, 52);

                if (!array[index].IsUsed)
                {
                    _sumcomputer += (int)array[index].Cards;
                    Console.WriteLine($"{array[index].Cards} - {array[index].Suit} ");
                    array[index].IsUsed = true;

                }
            }
            if (_sumcomputer > 18 && _sumcomputer <= 21)
            {
                Console.WriteLine("Enough!");
                raz = true;
            }
            if (_sumcomputer > 21)
            {
                Console.WriteLine("Enough!");
                raz = true;
            }

        }

        if (_sumplayer == 0) // Calling user's game mathod 
        {
            Console.WriteLine("Your try");
            PlayerStart();
        } else
        {
            Console.WriteLine(new string('-', 100));
            Consider(); //Count who won
        }
    }

    public void PlayerStart()
    {
        bool raz = false;
        _sumplayer = TwoFirstCards();
        if (_sumplayer == 22)
        {
            Console.WriteLine("You have BlackJack!!!");
            if (_sumcomputer == 0)
            {
                Console.WriteLine("Computer's turn");
                Console.WriteLine(new string('-', 100));
                ComputerStart(); // Calling computer's game mathod 
                raz = true;
            } else
            {
                Console.WriteLine(new string('-', 100));
                Consider(); //Count who won
                raz = true;
            }
        }

        while (!raz)
        {
            Console.WriteLine("Yet or that's enough? Press \"enter\" if you want or another button if yoo want to stop");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.KeyChar == 13)
            {
                int index = r.Next(0, 52);
                bool p = false;
                while (!p)
                {
                    if (!array[index].IsUsed)
                    {
                        _sumplayer += (int)array[index].Cards;
                        Console.WriteLine($"{array[index].Cards} - {array[index].Suit} ");
                        array[index].IsUsed = true;
                        p = true;
                    }
                }
            } else
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
            ComputerStart(); // Calling computer's game mathod 

        } else
        {
            Console.WriteLine(new string('-', 100));
            Consider(); //Count who won
        }
    }

    public void Consider()
    {
        if (_sumcomputer > _sumplayer && _sumcomputer <= _blackJackPoints)
        {
            Console.WriteLine($"Computer won! It has {_sumcomputer} points and you have {_sumplayer} points");
        } else if (_sumplayer > _sumcomputer && _sumplayer <= _blackJackPoints)
        {
            Console.WriteLine($"You won! Computer has {_sumcomputer} points and you have {_sumplayer} points");
        } else if (_sumcomputer <= _blackJackPoints && _sumplayer > _blackJackPoints)
        {
            Console.WriteLine($"Computer won! It has {_sumcomputer} points and you have {_sumplayer} points");
        } else if (_sumplayer <= _blackJackPoints && _sumcomputer > _blackJackPoints)
        {
            Console.WriteLine($"Player won! Computer has {_sumcomputer} points and you have {_sumplayer} points");
        } else if (_sumcomputer == _sumplayer && _sumplayer <= _blackJackPoints)
        {
            Console.WriteLine($"Dead head! You are both have {_sumplayer} points");
        } else if (_sumplayer > _blackJackPoints && _sumcomputer > _blackJackPoints)
        {
            Console.WriteLine($"Loosers.  Computer has {_sumcomputer} points and you have {_sumplayer} points");
        }

    }
}

