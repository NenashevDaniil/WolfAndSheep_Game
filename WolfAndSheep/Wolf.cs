using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfAndSheep
{
    internal class Wolf
    {
        private int _health;

        public char Sprite { get; }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }

        }
        public int XW { get; set; }
        public int YW { get; set; }

        public Wolf(int health, int xW, int yW)
        {
            XW = xW;
            YW = yW;
            _health = health;
            Sprite = 'W';
        }

        public void Update()
        {
            //Hunger += 2;
            Move(Program.rnd.Next(0, 5));
        }

        private void Move(int direction)
        {
            if (direction == 1)
                XW += 1;
            else if (direction == 2)
                YW += 1;
            else if (direction == 3)
                XW -= 1;
            else if (direction == 4)
                YW -= 1;
        }

        public void GetPos(out int x, out int y, char[,] map)
        {
            bool work = true;
            while (work)
            {

                if (XW >= 0 & YW >= 0 && XW < map.GetLength(0) & YW < map.GetLength(1))
                {
                    work = false;
                }
                else
                {
                    Move(Program.rnd.Next(0, 5));
                }
            }
            x = XW;
            y = YW;
        }
    }
}

