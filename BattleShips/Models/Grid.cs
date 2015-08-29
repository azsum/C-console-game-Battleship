namespace BattleShips.Contracts
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Engine;
    using Validations;

    public class Grid : IGrid
    {
        public static Grid InstanceOfGrid = new Grid();
        public static EngineMethod InstanceOfEngineMethod = new EngineMethod();
        private static char[,] gameOnGrid = InstanceOfGrid.GenerateGrid();
        private static char[,] shipGrid = Ship.InstanceOfShip.GridWithShips();
        private static IList<int> randomRows = EngineMethod.InstanceOfEngineMethod.GenerateRandomNumbers(totalShipsCount);
        private static int totalShipsCount = Constant.TotalShipsCount;
        private static IList<int> randomCols = EngineMethod.InstanceOfEngineMethod.GenerateRandomNumbers(totalShipsCount);
        private Ship ship = new Ship();
        private int row = Constant.GridRows;
        private int col = Constant.GridCols;
        private char missSymbol = Constant.MissSymbol;
        private char shipSymbol = Constant.ShipSymbol;
        private string digits = Constant.Digits;
        private string battleshipSunkMessage = Constant.BattleshipSunkMessage;
        private string destroyer1Sunk = Constant.Destroyer1SunkMessage;
        private string destroyer2Sunk = Constant.Destroyer2SunkMessage;
      
        private char symbol;
        private int credits = Engine.InstanceEngine.DefaultCredits;
        private char[] letters = { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        private int countShots = 0;

        public void PrintGrid(char[,] grid)
        {
            Console.WriteLine(this.digits);
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(this.letters[i]);
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j]);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }
        }

        public void UpdateGrid(PlayerShot playerShot)
        {
            IList<Ship> createShips = Ship.InstanceOfShip.CreateShips();
            var shotX = playerShot.CoordinateX;
            var shotY = playerShot.CoordinateY;

            if (shotX == 0)
            {
                shotX = shipGrid.GetLength(0) - 1;
            }

            if (shotY == 0)
            {
                shotY = shipGrid.GetLength(1) - 1;
            }

            if (shipGrid[shotX, shotY] == this.shipSymbol && gameOnGrid[shotX, shotY]
                    != this.shipSymbol)
            {
                gameOnGrid = playerShot.SuccessfullyShot(shotX, shotY, gameOnGrid, this.shipSymbol);

                int battleshipRow, battleshipCol, destroyer1Row, destroyer1Col, destroyer2Row, destroyer2Col;

                battleshipRow = createShips[0].CoordinateX;
                battleshipCol = createShips[0].CoordinateY;
                destroyer1Row = createShips[1].CoordinateX;
                destroyer1Col = createShips[1].CoordinateY;
                destroyer2Row = createShips[2].CoordinateX;
                destroyer2Col = createShips[2].CoordinateY;

                bool isBattleship = gameOnGrid[battleshipRow, battleshipCol] == this.shipSymbol;
                bool isDestroyer1 = gameOnGrid[destroyer1Row, destroyer1Col] == this.shipSymbol;
                bool isDestroyer2 = gameOnGrid[destroyer2Row, destroyer2Col] == this.shipSymbol;

                bool isBattleshipSunk = Validation.InstanceOfValidation.IsBattleshipSunk(gameOnGrid, battleshipRow, battleshipCol);

                bool isDestroyer1HullHorizontal = Validation.InstanceOfValidation.IsDestroyerHullHorizontal(gameOnGrid, destroyer1Row, destroyer1Col);
                bool isDestroyer2HullHorizontal = Validation.InstanceOfValidation.IsDestroyerHullHorizontal(gameOnGrid, destroyer2Row, destroyer2Col);

                bool isDestroyer1HullVertical = Validation.InstanceOfValidation.IsDestroyerHullVertical(gameOnGrid, destroyer1Row, destroyer1Col);
                bool isDestroyer2HullVertical = Validation.InstanceOfValidation.IsDestroyerHullVertical(gameOnGrid, destroyer2Row, destroyer2Col);

                bool isDestroyer1Sunk = isDestroyer1 == true && (isDestroyer1HullHorizontal == true
                    || isDestroyer1HullVertical == true);

                bool isDestroyer2Sunk = isDestroyer2 == true && (isDestroyer2HullHorizontal == true
                    || isDestroyer2HullVertical == true);

                bool isPlayerWin = isBattleshipSunk == true && isDestroyer1Sunk == true && isDestroyer2Sunk == true;

                if (isBattleship == true && isBattleshipSunk == true)
                {
                    Console.WriteLine(this.battleshipSunkMessage);
                }

                if (isDestroyer1Sunk == true)
                {
                    Console.WriteLine(this.destroyer1Sunk);
                }

                if (isDestroyer2Sunk == true)
                {
                    Console.WriteLine(this.destroyer2Sunk);
                }

                if (isPlayerWin == true)
                {
                    int shots = Engine.InstanceEngine.Shots;
                    InstanceOfEngineMethod.PlayerWin(shots);
                }
            }
            else
            {
                playerShot.OnShotMiss(shotX, shotY, gameOnGrid, this.missSymbol);
            }

            this.countShots++;
            this.PrintGrid(gameOnGrid);
        }

        public char[,] GenerateGrid()
        {
            var grid = new char[this.row + 1, this.col + 1];
            Console.WriteLine(this.digits);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write(this.letters[i]);

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (j < 1 || i < 1)
                    {
                        this.symbol = ' ';
                    }
                    else
                    {
                        this.symbol = '.';
                    }

                    grid[i, j] = this.symbol;
                    Console.Write(grid[i, j]);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }

            return grid;
        }
    }
}