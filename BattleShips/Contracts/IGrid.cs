namespace BattleShips.Contracts
{
    public interface IGrid
    {
        void PrintGrid(char[,] grid);

        void UpdateGrid(PlayerShot playerShot);

        char[,] GenerateGrid();
    }
}