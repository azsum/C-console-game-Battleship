namespace BattleShips.Contracts
{
    public interface IPlayerShot
    {
        void ConvertInputToCoordinates(string input, ref PlayerShot playerShot);

        char[,] SuccessfullyShot(int x, int y, char[,] gameOnGrid, char shipSymbol);

        void OnShotMiss(int x, int y, char[,] gameOnGrid, char missSymbol);
    }
}