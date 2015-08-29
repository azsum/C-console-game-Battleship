namespace BattleShips.Commands
{
    using System;
    using Contracts;
    using Engine;

    public class Command : EngineMethod, ICommand
    {
        private char[,] showCommand = Ship.InstanceOfShip.GridWithShips();

        public void Show()
        {
            Grid.InstanceOfGrid.PrintGrid(this.showCommand);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}