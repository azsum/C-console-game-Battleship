namespace BattleShips.Contracts
{
    using System.Collections.Generic;

    public interface IShip
    {
        List<Ship> CreateShips();

        void ShipIsHitted(PlayerShot playerShot, Ship ship, char[,] gameOnGrid, char shipSymbol);

        void ShipIsDestroyed(Ship ship);

        void InsertShipsOnGrid(char shipSymbol, char[,] grid, ref int destroyersCount, ref int battleshipsCount, int row, int col, bool isRowEmpty, bool isColEmpty, bool isBattleship);

        char[,] GridWithShips();
    }
}