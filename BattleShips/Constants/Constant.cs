namespace BattleShips.Constants
{
    public class Constant
    {
        public const int RandomNumberMinValue = 0;
        public const int DestroyerLength = 4;
        public const int BattleshipLength = 5;
        public const int ShipHealth = 100;
        public const int GridRows = 10;
        public const int GridCols = 10;
        public const int TotalShipsCount = 3;
        public const int StartCredits = 20;
        public const int Millisecond = 6000;
        public const char ShipSymbol = 'X';
        public const char DotSymbol = '.';
        public const char MissSymbol = '-';
        public const string Digits = "   1 2 3 4 5 6 7 8 9 0";
        public const string BattleshipSunkMessage = "The battleship is sunk";
        public const string Destroyer1SunkMessage = "The first destroyer is sunk";
        public const string Destroyer2SunkMessage = "The second battleship is sunk";
        public const string ShotMissMessage = "You missed\r\n";
        public const string WelcomeMessage = "Welcome to the game Battleships.\r\n\r\nThere are tree hidden ships on the grid. You must guess where they are by entering \r\ncoordinates to shot on ship. Once all three ships are destroyed, the game finish.\r\nType 'show' to cheat and take a look where the ships are,\r\nor type  'exit' for exiting the game.\r\nYou have 20 shots.\r\nHave fun!\r\n";
        public const string InvalidInputMessage = "Please enter one letter from A-J and one digit from 0-9 without whitespace between them";
        public const string InputMessage = "\r\nPlease enter the coordinates of shot e.g. C4";
    }
}