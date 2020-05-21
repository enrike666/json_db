using System;
using System.Collections.Generic;
using System.Text;

namespace JsonDB
{
    public class CommandParser
    {
        public static string GetTypeCommand(String str)
        {
            string[] args = str.Split(" ");
            var argType = args[0];
            var t = argType.Length;
            return argType.Substring(1, argType.Length-1);
        }

        public static Dictionary<string, string> ParseParams(string[] str)
        {
            Dictionary<string, string> parametrs = new Dictionary<string, string>();
            try
            {
                for (var i = 1; i <= str.Length-1; i++)
                {
                    string[] param = str[i].Split(":");
                    parametrs.Add(param[0], param[1]);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return parametrs;
        }
    }
}
