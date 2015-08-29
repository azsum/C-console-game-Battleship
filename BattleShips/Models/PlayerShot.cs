namespace BattleShips.Contracts
{
    using System;
    using Constants;
    using Engine;

    public class PlayerShot : IPlayerShot
    {
        public static PlayerShot InstanceOfPlayerShot = new PlayerShot();
        public static EngineMethod InstanceOfEngineMethod = new EngineMethod();
        private static int credits = 25;
        private int coordinateX;
        private int coordinateY;
        private string input = string.Empty;
        private char shipSymbol = Constant.ShipSymbol;
        private string shotMissMessage = Constant.ShotMissMessage;

        public PlayerShot()
        {
        }

        public PlayerShot(int x, int y)
        {
            this.coordinateX = x;
            this.coordinateY = y;
        }

        public int CoordinateX
        {
            get
            {
                return this.coordinateX;
            }

            set
            {
                this.coordinateX = value;
            }
        }

        public int CoordinateY
        {
            get
            {
                return this.coordinateY;
            }

            set
            {
                this.coordinateY = value;
            }
        }

        public void ConvertInputToCoordinates(string input, ref PlayerShot playerShot)
        {
            int x = input[0] % 32;
            int y = (int)char.GetNumericValue(input[1]);
            playerShot.coordinateX = x;
            playerShot.CoordinateY = y;
        }

        public char[,] SuccessfullyShot(int x, int y, char[,] gameOnGrid, char shipSymbol)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You hit the ship\r\n");
            gameOnGrid[x, y] = shipSymbol;
            Console.ForegroundColor = ConsoleColor.White;
            return gameOnGrid;
        }

        public void OnShotMiss(int x, int y, char[,] gameOnGrid, char missSymbol)
        {
            if (gameOnGrid[x, y] != this.shipSymbol)
            {
                Console.WriteLine(this.shotMissMessage);
                gameOnGrid[x, y] = missSymbol;
            }
            else
            {
                Console.WriteLine(this.shotMissMessage);
            }

            credits--;
            EngineMethod.InstanceOfEngineMethod.Credits(credits);
        }
    }
}