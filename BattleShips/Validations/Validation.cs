namespace BattleShips.Validations
{
    using System;
    using System.Text.RegularExpressions;
    using Constants;

    public class Validation : IValidation
    {
        public static Validation InstanceOfValidation = new Validation();
        private string invalidInput = Constant.InvalidInputMessage;
        private char shipSymbol = Constant.ShipSymbol;

        public bool AreInputCoordinates(string input)
        {
            bool areValidCoordinates = input.Length == 2 &&
               Regex.IsMatch(input, "^[A-J]{1}[0-9]{1}$") && input != null;
            if (areValidCoordinates == true)
            {
                return true;
            }
            else if (areValidCoordinates == false && this.IsInputCommand(input) == false)
            {
                Console.WriteLine(this.invalidInput);
            }

            return false;
        }

        public bool IsInputCommand(string input)
        {
            bool isValidCommand = input == "show" || input == "exit";
            if (isValidCommand == true)
            {
                return true;
            }

            return false;
        }

        public void ValidateShipsInsertion(char shipSymbol, char[,] grid, out int destroyersCount, out int battleshipsCount, out bool isRowEmpty, out bool isColEmpty, out bool isBattleship, out bool isDestroyer)
        {
            var row = 0;
            var col = 0;
            destroyersCount = 0;
            battleshipsCount = 0;

            isRowEmpty = grid[row, col] != shipSymbol && grid[row + 1, col] != shipSymbol &&
                     grid[row + 2, col] != shipSymbol && grid[row + 3, col] != shipSymbol && grid[row + 4, col] != shipSymbol && grid.Length - row + 3 >= 5;

            isColEmpty = grid[row, col] != shipSymbol && grid[row, col + 1] != shipSymbol &&
                grid[row, col + 2] != shipSymbol && grid[row, col + 3] != shipSymbol &&
                grid[row, col + 3] != shipSymbol && grid.Length - col + 3 >= 5;

            isBattleship = (row <= 5 || col <= 5) && battleshipsCount < 2;
            isDestroyer = (col <= 6 || row <= 6) && destroyersCount < 3;
        }

        public bool IsDestroyerHullVertical(char[,] gameOnGrid, int x, int y)
        {
            var isHorizontal = gameOnGrid[x + 1, y] == this.shipSymbol && gameOnGrid[x + 2, y] == this.shipSymbol
                && gameOnGrid[x + 3, y] == this.shipSymbol;

            if (isHorizontal == true)
            {
                return true;
            }

            return false;
        }

        public bool IsDestroyerHullHorizontal(char[,] gameOnGrid, int x, int y)
        {
            var isHorizontal = gameOnGrid[x, y + 1] == this.shipSymbol && gameOnGrid[x, y + 2] == this.shipSymbol
                && gameOnGrid[x, y + 3] == this.shipSymbol;

            if (isHorizontal == true)
            {
                return true;
            }

            return false;
        }

        public bool IsBattleshipSunk(char[,] gameOnGrid, int x, int y)
        {
            var isBattleshipSunk = gameOnGrid[x + 1, y] == this.shipSymbol && gameOnGrid[x + 2, y] == this.shipSymbol && gameOnGrid[x + 3, y] == this.shipSymbol && gameOnGrid[x + 4, y] == this.shipSymbol;

            if (isBattleshipSunk == true)
            {
                return true;
            }

            return false;
        }
    }
}