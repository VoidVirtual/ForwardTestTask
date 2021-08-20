using System.IO;
using Newtonsoft.Json;

namespace ForwardTestTask
{
    public abstract class Engine
    {
        public abstract EngineTestResult Accept(IEngineTester tester);
        protected Engine()
        {
            enginesCount++;
            Id = enginesCount;
        }
        public static Engine CreateICEngine(string filepath)
        {
            using (StreamReader engineFile = File.OpenText(filepath)) 
            {
                JsonSerializer serializer = new JsonSerializer();
                return (Engine)serializer.Deserialize(engineFile, typeof(ICEngine));
            }
        }
        static private int enginesCount = 0;
        public int Id { get; }
    }
}
