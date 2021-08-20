using System;
namespace ForwardTestTask
{
    public class OverheatTestResult : EngineTestResult
    {
        public OverheatTestResult(bool overheated)
        {
            this.overheated = overheated;
        }
        public override string GetMessage()
        {
            if (overheated) 
            {
                return "Test failed!";
            }
            else
            {
                return "Test passed!";
            }
        }
        private bool overheated;
    }
    public class PositiveOverheatTestResult : OverheatTestResult
    {
        public PositiveOverheatTestResult(double overheatTime):
                                                base(true)
        {
            this.overheatTime = overheatTime;
        }
        public override string GetMessage()
        {
            return base.GetMessage()
                        + " Overheat in "
                        + overheatTime 
                        + " second(s).";
        }
        private readonly double overheatTime;
    }
    public class NegativeOverheatTestResult : OverheatTestResult
    {
        public NegativeOverheatTestResult(double engineTemp) :
                                                base(false)
        {
            this.engineTemp = engineTemp;
        }
        public override string GetMessage()
        {
            return base.GetMessage() +" Temperature stabilized at " 
                            + engineTemp 
                            + "celsium degrees.";
        }
        private readonly double engineTemp;
    }
}
