namespace BattleShips.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Constants;
    using Contracts;

    public class EngineMethod : IEngineMethod
    {
        public static EngineMethod InstanceOfEngineMethod = new EngineMethod();
        private static int millisecond = Constant.Millisecond;
        private static int totalShipNumber = Constant.TotalShipsCount;
        private static List<int> generateRandomNumbersHorizontally = InstanceOfEngineMethod.GenerateRandomNumbers(totalShipNumber);
        private static List<int> generateRandomNumbersVertically = InstanceOfEngineMethod.GenerateRandomNumbers(totalShipNumber);
        private int minValue = Constant.RandomNumberMinValue;
        private string wellcomeMessage = Constant.WelcomeMessage;
        private Random random = new Random();
       
        public List<int> GenerateRandomNumbers(int totalShipsNumber)
        {
            List<int> numbers = new List<int>();
            List<int> values = new List<int>() { 1, 2, 3, 4, 5 };
            for (int i = 0; i < totalShipsNumber; ++i)
            {
                int next = this.random.Next(this.minValue, values.Count);
                numbers.Add(values[next]);
                values.RemoveAt(next);
            }

            numbers.Sort();
            return numbers;
        }

        public void Credits(int credits)
        {
            if (credits > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("credits left :{0}\r\n", credits);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (credits == 0)
            {
                this.GameOver();
            }
        }

        public void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.wellcomeMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("GAME OVER\r\n");
            Thread.Sleep(millisecond);
            Environment.Exit(0);
        }

        public void PlayerWin(int shots)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Well done! You completed the game in {0} shots\r\n", shots);
            Thread.Sleep(millisecond);
            Environment.Exit(0);
        }
    }
}