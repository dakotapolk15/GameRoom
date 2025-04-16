

using System;

namespace GamingRoom 
{
    public class SingletonTester
    {
        public void TestSingleton()
        {
            Console.WriteLine("About to test the singleton...");

            GameService service = GameService.GetInstance();

            for (int i = 0; i < service.GetGameCount(); i++) 
            {
                Console.WriteLine(service.GetGame(i));
            }
        }
    }
}
