namespace BattleShips.Contracts
{
    using System.Collections.Generic;

    public interface IEngineMethod
    {
        void PlayerWin(int shots);

        void GameOver();

        void WelcomeMessage();

        void Credits(int credits);

        List<int> GenerateRandomNumbers(int totalShipsNumber);
    }
}