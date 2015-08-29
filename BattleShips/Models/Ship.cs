namespace BattleShips.Contracts
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Engine;
    using Validations;

    public class Ship : IShip
    {
        public static Ship InstanceOfShip = new Ship();
        private static int totalShipsCount = Constant.TotalShipsCount;
        private static IList<int> randomRows = EngineMethod.InstanceOfEngineMethod.GenerateRandomNumbers(totalShipsCount);
        private static IList<int> randomCols = EngineMethod.InstanceOfEngineMethod.GenerateRandomNumbers(totalShipsCount);
        private int row = Constant.GridRows;
        private int col = Constant.GridCols;
        private int health = Constant.ShipHealth;
        private char shipSymbol = Constant.ShipSymbol;
        private int shipCount = Constant.TotalShipsCount;
        private int coordinateX;
        private int coordinateY;
        private int size;

        public Ship()
        {
        }

        public Ship(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public Ship(int health, int size, int coordinateX, int coordinateY)
            : this(coordinateX, coordinateY)
        {
            this.health = health;
            this.size = size;
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

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public List<Ship> CreateShips()
        {
            List<Ship> shipList = new List<Ship>();
            Ship battleShip = new Ship();
            Ship destroyer1 = new Ship();
            Ship destroyer2 = new Ship();
            for (int i = 0; i < this.shipCount; i++)
            {
                this.row = randomRows[i];
                this.col = randomCols[i];
                if (i == 0)
                {
                    battleShip.CoordinateX = this.row;
                    battleShip.CoordinateY = this.col;
                }
                else if (i == 1)
                {
                    destroyer1 = new Ship(this.row, this.col);
                    destroyer1.CoordinateX = this.row;
                    destroyer1.CoordinateY = this.col;
                }
                else
                {
                    destroyer2 = new Ship(this.row, this.col);
                    destroyer2.CoordinateX = this.row;
                    destroyer2.CoordinateY = this.col;
                }
            }

            shipList.Add(battleShip);
            shipList.Add(destroyer1);
            shipList.Add(destroyer2);
            return shipList;
        }

        public char[,] GridWithShips()
        {
            char[,] grid = new char[this.row + 1, this.col + 1];
            int destroyer, battleship, row, col;
            bool isRowEmpty, isColEmpty, isBattleship, isDestroyer;

            Validation.InstanceOfValidation.ValidateShipsInsertion(this.shipSymbol, grid, out destroyer, out battleship, out isRowEmpty, out isColEmpty, out isBattleship, out isDestroyer);

            for (int i = 0; i < this.shipCount; i++)
            {
                row = randomRows[i];
                col = randomCols[i];
                this.InsertShipsOnGrid(this.shipSymbol, grid, ref destroyer, ref battleship, row, col, isRowEmpty, isColEmpty, isBattleship);
            }

            return grid;
        }

        public void InsertShipsOnGrid(char shipSymbol, char[,] grid, ref int destroyersCount, ref int battleshipsCount, int row, int col, bool isRowEmpty, bool isColEmpty, bool isBattleship)
        {
            if (isBattleship == true && battleshipsCount == 0)
            {
                if (isRowEmpty && row + 5 <= grid.GetLength(0))
                {
                    grid[row, col] = shipSymbol;
                    grid[row + 1, col] = shipSymbol;
                    grid[row + 2, col] = shipSymbol;
                    grid[row + 3, col] = shipSymbol;
                    grid[row + 4, col] = shipSymbol;
                }
                else if (isColEmpty && col + 5 <= grid.GetLength(1))
                {
                    grid[row, col] = shipSymbol;
                    grid[row, col + 1] = shipSymbol;
                    grid[row, col + 2] = shipSymbol;
                    grid[row, col + 3] = shipSymbol;
                    grid[row, col + 4] = shipSymbol;
                }

                battleshipsCount++;
            }
            else if (destroyersCount < 3)
            {
                if (isColEmpty && (col + 4 <= grid.GetLength(1)))
                {
                    grid[row, col] = shipSymbol;
                    grid[row, col + 1] = shipSymbol;
                    grid[row, col + 2] = shipSymbol;
                    grid[row, col + 3] = shipSymbol;
                }
                else if (isRowEmpty && row + 4 <= grid.GetLength(0))
                {
                    grid[row, col] = shipSymbol;
                    grid[row + 1, col] = shipSymbol;
                    grid[row + 2, col] = shipSymbol;
                    grid[row + 3, col] = shipSymbol;
                }

                destroyersCount++;
            }
        }

        public void ShipIsDestroyed(Ship ship)
        {
            if (ship.Health == 0)
            {
                Console.WriteLine("Ship is sunk");
            }
        }

        public void ShipIsHitted(PlayerShot playerShot, Ship ship, char[,] gameOnGrid, char shipSymbol)
        {
            if (ship.health > 0 && ship.health < this.health)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You hit the ship\r\n");
                gameOnGrid[playerShot.CoordinateX, playerShot.CoordinateY] = shipSymbol;
                ship.Health -= 20;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}