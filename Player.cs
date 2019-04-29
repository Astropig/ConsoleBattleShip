using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Player
    {
        private Map map;
        private int numberOfShips;
        private string name;
        public Player(int key, string name)
        {
            map = new Map(key);
            this.name = name;
            numberOfShips = 3;
            
           
        }

        public bool IsAlive()
        {
            return map.CheckForShip();
        }

        public string GetName()
        {
            return name;
        }

        public void CheckHit(int x, int y)
        {
            var grid = map.GetGrid();
            if (grid[x, y] == 'O')
            {
                map.EditGrid(x,y,'H');
                map.EditDummy(x,y,'H');
            }
            else
            {
                map.EditGrid(x, y, 'M');
                map.EditDummy(x, y, 'M');

            }
        }

        public Map GetMap()
        {
            return map;
        }
    }
}
