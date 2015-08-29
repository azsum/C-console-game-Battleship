namespace BattleShips
{
    public class StartGame
    {
        public static void Main(string[] args)
        {
            var instance = Engine.Engine.InstanceEngine;
            instance.GameOn();
        }
    }
}