using System;
namespace ForwardTestTask
{
    public class OverheatTester: IEngineTester
    {
        public OverheatTester(double areaTemp, double timeStep, double minimalTempStep)
        {
            this.areaTemp = areaTemp;
            this.timeStep = timeStep;
            this.minimalTempStep = minimalTempStep;
        }
        public string GetTestType()
        {
            return "Overheat";
        }
        public EngineTestResult TestICEngine(ICEngine engine)
        {
            double overheatTemp = engine.OverheatTemperature;
            var velocityToRollingMonemt = engine.VelocityToRollingMonemt;
            double i = engine.I;
            double c = engine.C;
            double hv = engine.Hv;
            double hm = engine.Hm;


            double engineTemp = areaTemp;
            double time = 0.0;
            double v = 0.0;

            while (engineTemp < engine.OverheatTemperature)
            {
                double m = velocityToRollingMonemt(v);
                v += m * timeStep / i; ; 
                double vh = (m * hm) + (v * v * hv);
                double vc = c * (areaTemp - engineTemp);
                time += timeStep;
                double tempStep = timeStep * (vh + vc);
                if (tempStep <= minimalTempStep)
                {
                    return new NegativeOverheatTestResult(engineTemp);
                }
                engineTemp += tempStep;
            }
            return  new PositiveOverheatTestResult(time);
        }
        private readonly double areaTemp;
        private readonly double timeStep;
        private readonly double minimalTempStep;
    }
}
