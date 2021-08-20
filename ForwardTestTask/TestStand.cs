using System.Collections.Generic;
using System.IO;
namespace ForwardTestTask
{
    public class TestStand
    {
        public TestStand(TextWriter logger)
        {
            this.logger = logger;
        }
        public void AddICEngine(string filepath)
        {
            var engine = Engine.CreateICEngine(filepath);
            if (engine != null)
            {
                engines.Add(engine);
            }
        }
        public void AddOverheatTest(double areaTemp,
                                        double timeStep, 
                                              double mininalTempStep)
        {
            testers.Add(new OverheatTester(areaTemp, timeStep, mininalTempStep));
        }
        public void RunAllTests()
        {
            foreach(var engine in engines)
            {
                foreach(var tester in testers)
                {
                    logger.WriteLine("____________________________________________________");
                    logger.Write(tester.GetTestType());
                    logger.WriteLine(" test started.");
                    logger.WriteLine("Engine id: " + engine.Id);
                    logger.WriteLine(engine.Accept(tester).GetMessage());
                    logger.WriteLine("____________________________________________________\n");
                }
            }
        }
        private List<Engine> engines = new List<Engine>();
        private List<IEngineTester> testers = new List<IEngineTester>();
        private TextWriter logger; 
    }

}
