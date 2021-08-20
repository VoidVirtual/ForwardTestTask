using System;
using System.Collections.Generic;
using System.IO;
namespace ForwardTestTask
{
    public class ConfigFileParser
    {
        public static Dictionary<string, object> ToDictionary(string filepath)
        {
            var result = new Dictionary<string, object>();
            var reader = new StreamReader(filepath);
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] words = line.Split(new char[] { ' ' });
                string key = words[0];
                if (words.Length < 2)
                {
                    throw new Exception();
                }
                else if (words.Length > 2)
                {
                    var list = new List<object>(words.Length - 1);
                    foreach (string word in words)
                    {
                        list.Add(word);
                    }
                    result.Add(key, list);
                }
                else
                {
                    result.Add(key, words[1]);
                }
            }
            return result;
        }

    }
}
