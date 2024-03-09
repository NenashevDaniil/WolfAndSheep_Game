using System.Linq.Expressions;

namespace WolfAndSheep
{
    internal class Program
    {
        public static Random rnd = new Random();
        public static char[,] map = new char[20, 20];
        static void Main()
        {

            for (int x = 0; x < map.GetLength(0); x++)
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = '-';
                }
            Wolf wolf = new Wolf(100, 9, 9);
            List <Sheep> sheep = new List<Sheep>(); 
            for (int i = 0; i < 4; i++)
            {
                int xS = rnd.Next(0, map.GetLength(0));
                int yS = rnd.Next(0, map.GetLength(1));
                sheep.Add(new Sheep(xS, yS, 100, 0));
            }
            GetStartedGrass(map, rnd.Next(0, 5));
            while (true)
            {
                for (int i = 0; i < sheep.Count; i++)
                {
                    sheep[i].GetPos(out int xS, out int yS, map);
                    map[xS, yS] = '-';
                    sheep[i].Update();
                    sheep[i].GetPos(out xS, out yS, map);
                    map[xS, yS] = sheep[i].Sprite;
                }
                wolf.GetPos(out int xW, out int yW, map);
                map[xW, yW] = '-';
                wolf.Update();
                wolf.GetPos(out xW, out yW, map);
                map[xW, yW] = wolf.Sprite;
                RenderMap(map);
                IsSheepEated(ref sheep, wolf);
                GetGrass(map, rnd.Next(0, 5));
                Console.ReadKey();
            }
        }

        static void RenderMap(char[,] map)
        {
            Console.Clear();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    switch (map[x,y])
                    {
                        case 'v':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '-':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 'W':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'S':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                    }
                    Console.Write(map[x, y]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void GetStartedGrass(char[,] map, int direction)
        {
            for (int i = 0; i <= 8; i++)
            {
                GetGrass(map, rnd.Next(0, 4));
            }
        }
        static void GetGrass(char[,] map, int direction)
        {
            if (direction == 0 || direction == 1)
            {

                int xInit = rnd.Next(0, map.GetLength(0));
                int yInit = rnd.Next(0, map.GetLength(1));
                if (map[xInit, yInit] == '-')
                {
                    map[xInit, yInit] = 'v';
                }
            }
        }
        static void IsSheepEated(ref List <Sheep> sheep, Wolf wolf)
        {
            for (int i = 0; i < sheep.Count; i++)
            {
                if (sheep[i].XS == wolf.XW && sheep[i].YS == wolf.YW)
                {
                    sheep.RemoveAt(i);
                }

            }

        } 
    }
}
