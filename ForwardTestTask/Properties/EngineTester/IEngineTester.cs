using System;
namespace ForwardTestTask
{
    public interface IEngineTester
    {
        EngineTestResult TestICEngine(ICEngine engine);
        string GetTestType();
    }
}
