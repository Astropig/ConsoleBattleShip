using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Map
    {
        private char[,] _grid = new char[10,10];
        private char[,] _dummyGrid = new char[10,10];
        private Random randNum;
        public Map(int key) {
            randNum = new Random(key);
            GenerateMap();
            GenerateDummy();
            PlaceShips();
        }

        public void GenerateMap()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                   _grid[x, y] = '*';
                }            
            }
        }

        private void GenerateDummy()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    _dummyGrid[x, y] = '*';
                }
            }
        }
        public void DisplayDummyMap()
        {
            Console.WriteLine();
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    Console.Write(_dummyGrid[x, y]);
                }
                Console.WriteLine();
            }
        }
        public void DisplayMap()
        {
            Console.WriteLine();
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    Console.Write(_grid[x, y]);             
                }
                Console.WriteLine();
            }
        }

        public void PlaceShips()
        {
            for (var t = 0; t < 3;t++)
            {
                var shipx = randNum.Next(3, 7);
                var shipy = randNum.Next(3, 7);
                

                if ((shipx < 8 && shipy < 8) && (shipx > 2 && shipy > 2))
                {
                    var direction = randNum.Next(1, 4);

                    switch (direction)
                    {
                        case 1:
                            for (var i = 0; i < 3; i++)
                                EditGrid(shipx + i, shipy, 'O');
                            break;
                        case 2:
                            for (int i = 0; i < 3; i++)
                                EditGrid(shipx - i, shipy, 'O');
                            break;
                        case 3:
                            for (int i = 0; i < 3; i++)
                                EditGrid(shipx, shipy + i, 'O');
                            break;
                        case 4:
                            for (int i = 0; i < 3; i++)
                                EditGrid(shipx, shipy - i, 'O');
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        public bool CheckForShip()
        {
            var isShips = true;
            var flag = 0;
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    if (_grid[x, y] == 'O')
                    {
                        flag++;
                    }
                }
            }

            if (flag == 0)
                isShips = false;
            return isShips;
        }

        public char[,] GetGrid()
        {
            return _grid;
        }

        public void EditDummy(int x, int y, char c)
        {
            _dummyGrid[x, y] = c;
        }

        public void EditGrid(int x, int y, char c)
        {
            _grid[x, y] = c;
        }
    }
}
