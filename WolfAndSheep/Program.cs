namespace WolfAndSheep
{
    internal class Program
    {
        public static Random rnd = new Random();
        public static char[,] map = new char[20, 20];
        static void Main()
        {
            //int h = 0;
            //int[] array = new int[100];
            //Sheep sh1 = new Sheep();

            ////sh1.Coordinate = new Coordinate();
            ////sh1.Coordinate.X = 1;
            ////sh1.Coordinate.Y = 2;

            ////sh1.Eat(1);
            ////Console.WriteLine(sh1.Hunger);
            //Sheep sh2 = new Sheep (4, 4, 100, 0);


            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = '-';
                }

            //Sheep sheep1 = new Sheep(5, 5, 100, 0);
            //sheep1.GetPos(out int xS, out int yS);
            //map[xS, yS] = sheep1.Sprite;
            //RenderMap(map);
            //while (true)
            //{
            //    sheep1.GetPos(out xS, out yS);
            //    map[xS, yS] = '-';
            //    sheep1.Update();
            //    sheep1.GetPos(out xS, out yS);
            //    map[xS, yS] = sheep1.Sprite;
            //    RenderMap(map);
            //    Console.ReadKey();
            //}
            Sheep[] sheeps = new Sheep[4];
            for (int i = 0; i < sheeps.Length; i++)
            {
                int xInit = rnd.Next(0, map.GetLength(0));
                int yInit = rnd.Next(0, map.GetLength(1));
                sheeps[i] = new Sheep(xInit, yInit, 100, 0);
            }
            while (true)
            {
                for (int i = 0; i < sheeps.Length; i++)
                {
                    sheeps[i].GetPos(out int xS, out int yS);
                    map[xS, yS] = '-';
                    sheeps[i].Update();
                    sheeps[i].GetPos(out xS, out yS);
                    if (map[xS, yS] == 'w')
                    {
                        //Кушаем
                    }
                    map[xS, yS] = sheeps[i].Sprite;
                    sheeps[i].Eat(rnd.Next(5, 10));
                }
                RenderMap(map);
                GetGrass(map);
                Console.ReadKey();
            }
        }

        static void RenderMap(char[,] map)
        {
            Console.Clear();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void GetGrass(char[,] map)
        {
            bool work = true;
            while (work)
            {
                int xInit = rnd.Next(0, map.GetLength(0));
                int yInit = rnd.Next(0, map.GetLength(1));
                if (map[xInit, yInit] == '-')
                {
                    map[xInit, yInit] = 'w';
                    work = false;
                }
            }
        }

        class Sheep
        {
            // Поля класса
            private int _health;
            //public Coordinate Coordinate { get; set; }
            private int _x;
            private int _y;

            public int Hunger { get; private set; }
            public char Sprite { get; }
            public int Health
            {
                set
                {
                    if (value < 0)
                        _health = 0;
                    else if (value > 100)
                        _health = 100;
                    else
                        _health = value;
                }
                get
                {
                    return _health;
                }
            }

            //public Sheep()
            //{
            //    _x = 5;
            //    _y = 5;
            //    _health = 100;
            //    Hunger = 0;
            //    Sprite = 'S';
            //}

            public Sheep(int x, int y, int health, int hunger)
            {
                _x = x;
                _y = y;
                _health = health;
                Hunger = hunger;
                Sprite = 'S';
            }

            public void Eat(int foodMass)
            {
                Hunger -= foodMass;
            }

            public void Update()
            {
                Hunger += 2;
                Move(Program.rnd.Next(0, 5));
            }

            private void Move(int direction)
            {
                if (direction == 1)
                    _x += 1;
                else if (direction == 2)
                    _y += 1;
                else if (direction == 3)
                    _x -= 1;
                else if (direction == 4)
                    _y -= 1;
            }

            public void GetPos(out int x, out int y)
            {
                bool work = true;
                while (work)
                {

                    if (_x >= 0 & _y >= 0 && _x <= map.GetLength(0) & _y <= map.GetLength(1))
                    {
                        work = false;
                    }
                    else
                    {
                        Move(Program.rnd.Next(0, 5));
                    }
                }
                x = _x;
                y = _y;
            }
        }

        //class Coordinate
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }

        //}

    }
}
