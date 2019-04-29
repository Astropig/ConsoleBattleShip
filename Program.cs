using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        public static void Attack(Player defender, int x, int y)
        {
            defender.CheckHit(x, y);      
        }

        public static void Clear()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("");
            }
        }

        public static bool NumberCheck(string num, int range)
        {
            var isNum = false;
            if (int.TryParse(num, out var number))
            {
                if(number <= range && number > 0)
                     isNum= true;
            }

            return isNum;
        }

        public static void Menu(Player player, Player enemey)
        {
            var choice = 0;
            var inMenu = true;
            while (inMenu)
            {
               Console.WriteLine(player.GetName());
               Console.WriteLine("ShowMap: 1");
               Console.WriteLine("Show Strike Map: 2");

               Console.WriteLine("Attack: 3");
               string Input = Console.ReadLine();
                Console.Clear();
                if (NumberCheck(Input, 3))
                {
                    choice = Convert.ToInt32(Input);
                }
                else
                {
                    Console.WriteLine("not Valid");
                }
                

                if (choice == 0)
                {
                    Menu(player, enemey);

                }
                if (choice == 1)
                {
                    player.GetMap().DisplayMap();
                    choice = 0;
                }else if (choice == 2)
                {
                    enemey.GetMap().DisplayDummyMap();
                    choice = 0;
                }else if (choice == 3)
                {
                    Console.WriteLine("enter X coord bewtween 1-10");
                    var coord1 = Console.ReadLine();
                    if (NumberCheck(coord1, 10))
                    {
                        var x = Convert.ToInt32(coord1);
                        Console.WriteLine("enter Y coord bewtween 1-10");
                        var coord2 = Console.ReadLine();

                        if (NumberCheck(coord2, 10))
                        {
                            var y = Convert.ToInt32(coord2);
                            Attack(enemey, y-1,x-1);
                            inMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("not vaild");
                            choice = 0;

                        }
                    }
                    else
                    {
                        Console.WriteLine("not vaild");
                        choice = 0;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var rand = new Random();
            var player1 = new Player(rand.Next(0,1000), "Player One");
            var player2 = new Player(rand.Next(0,1000), "Player Two");
            var isGameActive = true;

            

            
            while (true)
            {
                if(player1.IsAlive())
                    Menu(player1,player2);
                else
                {
                    Console.WriteLine("player 2 Wins");
                    break;
                }
                if (player2.IsAlive())
                    Menu(player2, player1);
                else
                {
                    Console.WriteLine("player 1 Wins");
                    break;

                }

            }
        }
    }
}
