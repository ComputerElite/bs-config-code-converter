using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeConverterTry
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doit = true;
            List<String> declares = new List<string>();
            List<String> inits = new List<string>();
            while(doit)
            {
                String input = Console.ReadLine();
                if (input == "") break;
                String varName = Regex.Match(input, "\"[A-Za-z1-9]+\"").Value;
                varName = varName.Substring(1, varName.Length - 2);
                String varType = Regex.Match(input, "Set(bool|float|int)", RegexOptions.IgnoreCase).Value;
                varType = varType.Substring(3);
                String varValue = Regex.Match(input, "(true|false|-?[0-9]+\\.?[0-9]?f?)", RegexOptions.IgnoreCase).Value;
                declares.Add("DECLARE_VALUE(" + varName + ", " + varType.ToLower() + ", \"" + varName + "\", " + varValue + ");");
                inits.Add("INIT_VALUE(" + varName + ");");
            }
            String finished = "#pragma once\n#include \"extern/config-utils/shared/config-utils.hpp\"\n\nDECLARE_CONFIG(ModConfig,\n\n";
            foreach (String s in declares) finished += "    " + s + "\n";
            finished += "\n    INIT_FUNCTION(\n";
            foreach (String s in inits) finished += "        " + s + "\n";
            finished += "    )\n)";
            Console.WriteLine(finished);
            Console.ReadLine();
        }
    }
}
