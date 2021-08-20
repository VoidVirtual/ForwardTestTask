using System;
namespace ForwardTestTask
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var logger = Console.Out;
            TestStand testStand = new TestStand(logger);
            logger.WriteLine("Enter the environment temperature in celsium:");
            try
            {
                testStand.AddICEngine(@"../../res/engines/engine.json");
                double environmentTemp = Convert.ToDouble(Console.ReadLine());
                const double timeStep = 0.0001;
                const double minimalTempStep = 0.0000001; 
                testStand.AddOverheatTest(environmentTemp, timeStep, minimalTempStep);
                testStand.RunAllTests();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
