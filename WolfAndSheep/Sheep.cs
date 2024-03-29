﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfAndSheep
{
    class Sheep
    {
        // Поля класса
        private int _health;

        public int XS { get; set; }
        public int YS { get; set; }

        public int Hunger { get; private set; }
        public char Sprite { get; }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                if (value < 0)
                    _health = 0;
                else if (value > 100)
                    _health = 100;
                else
                    _health = value;
            } 
        }   

        public Sheep(int x, int y, int health, int hunger)
        {
            XS = x;
            YS = y;
            _health = health;
            //Hunger = hunger;
            Sprite = 'S';
            Hunger = hunger;
        }

        public void Eat(int foodMass)
        {
            Hunger -= foodMass;
        }

        public void Update()
        {
            //Hunger += 2;
            Move(Program.rnd.Next(0, 5));
        }

        private void Move(int direction)
        {
            if (direction == 1)
                XS += 1;
            else if (direction == 2)
                YS += 1;
            else if (direction == 3)
                XS -= 1;
            else if (direction == 4)
                YS -= 1;
        }

        public void GetPos(out int x, out int y, char[,] map)
        {
            bool work = true;
            while (work)
            {

                if (XS >= 0 & YS >= 0 && XS < map.GetLength(0) & YS < map.GetLength(1))
                {
                    work = false;
                }
                else
                {
                    Move(Program.rnd.Next(0, 5));
                }
            }
            x = XS;
            y = YS;
        }
    }
}

    
   
