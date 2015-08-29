namespace BattleShips.Validations
{
    public interface IValidation
    {
        bool AreInputCoordinates(string input);

        bool IsInputCommand(string input);

        void ValidateShipsInsertion(char shipSymbol, char[,] grid, out int destroyersCount, out int battleshipsCount, out bool isRowEmpty, out bool isColEmpty, out bool isBattleship, out bool isDestroyer);

        bool IsBattleshipSunk(char[,] gameOnGrid, int x, int y);

        bool IsDestroyerHullHorizontal(char[,] gameOnGrid, int x, int y);

        bool IsDestroyerHullVertical(char[,] gameOnGrid, int x, int y);
    }
}