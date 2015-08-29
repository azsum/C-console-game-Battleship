namespace BattleShips.Engine
{
    using System;
    using Commands;
    using Contracts;
    using Validations;

    public sealed class Engine : EngineMethod, IEngine
    {
        public int DefaultCredits = Constants.Constant.StartCredits;
        public int Shots = 0;
        private static readonly object SyncLock = new object();
        private static volatile Engine instance = new Engine();
        private Command instanceOfCommand = new Command();
        private string inputMessage = Constants.Constant.InputMessage;

        private Engine()
        {
        }

        public static Engine InstanceEngine
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
                    {
                        if (instance == null)
                        {
                            instance = new Engine();
                        }
                    }
                }

                return instance;
            }
        }

        public void GameOn()
        {
            this.WelcomeMessage();
            while (true)
            {
                Console.WriteLine(this.inputMessage);
                string input = Console.ReadLine();
                bool areInputCoordinates = Validation.InstanceOfValidation.AreInputCoordinates(input);
                bool isInputCommand = Validation.InstanceOfValidation.IsInputCommand(input);
                if (areInputCoordinates == true)
                {
                    this.Shots++;
                    PlayerShot playerShot = new PlayerShot();
                    PlayerShot.InstanceOfPlayerShot.ConvertInputToCoordinates(input, ref playerShot);
                    Grid.InstanceOfGrid.UpdateGrid(playerShot);
                }
                else if (isInputCommand == true)
                {
                    switch (input)
                    {
                        case "show":
                            this.instanceOfCommand.Show();
                            break;

                        case "exit":
                            this.instanceOfCommand.Exit();
                            break;

                        default:
                            break;
                    }
                }
            }
        }
    }
}