using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ForwardTestTask
{
    public class ICEngine: Engine
    {
        [JsonConstructor]
        public ICEngine(List<double> v, List<double> m)
        {
            var pl = new PiecewiseLinearFunction(v, m);
            VelocityToRollingMonemt = pl.Calculate;
        }
        public override EngineTestResult Accept(IEngineTester tester)
        {
            return tester.TestICEngine(this);
        }
        public double I { get; set; }
        public double C { get; set; }
        public double Hm { get; set; }
        public double Hv { get; set; }
        public double OverheatTemperature { get; set; }
        public Func<double, double> VelocityToRollingMonemt { get; set; }
    }
}
