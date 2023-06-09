﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resPl = 0;
            int resMin1 = 0;
            int resMin2 = 0;
            int resPr = 1;
            int resDiv1 = 1;
            int resDiv2 = 1;
            int count = 0;
            string _file = "C:\\Users\\андрей\\Desktop\\file.txt";
            string _file2 = "C:\\Users\\андрей\\Desktop\\solution.txt";
            StreamReader File = new StreamReader(_file);
            using (StreamWriter writer = new StreamWriter(_file2, true))
            {
                while (!File.EndOfStream)
                {
                    string str = File.ReadLine();
                    Console.WriteLine(str);
                    var regexpLeft = new Regex(@"\d+");
                    var Operator = new Regex(@"(\+|\-|\*|\/)");
                    MatchCollection matchesLeft = regexpLeft.Matches(str);
                    MatchCollection matchesOperation = Operator.Matches(str);
                    foreach (Match match in matchesLeft)
                    {
                        foreach (Match match2 in matchesOperation)
                        {
                            if (match2.ToString() == "+")
                                resPl += int.Parse(match.Value);
                            else if (match2.ToString() == "-" && count % 2 == 0)
                                resMin1 = int.Parse(match.Value);
                            else if (match2.ToString() == "-" && count % 2 != 0)
                                resMin2 = int.Parse(match.Value);
                            else if (match2.ToString() == "*")
                                resPr *= int.Parse(match.Value);
                            else if (match2.ToString() == "/" && count % 2 == 0)
                                resDiv1 = int.Parse(match.Value);
                            else if (match2.ToString() == "/" && count % 2 != 0)
                                resDiv2 = int.Parse(match.Value);
                        }
                        count++;
                    }
                    foreach (Match match2 in matchesOperation)
                    {
                        if (match2.ToString() == "+")
                            writer.WriteLine(str + " " + resPl);
                        else if (match2.ToString() == "-")
                            writer.WriteLine(str + " " + (resMin1 - resMin2));
                        else if (match2.ToString() == "*")
                            writer.WriteLine(str + " " + resPr);
                        else if (match2.ToString() == "/")
                        {
                            if(resDiv2 == 0)
                                writer.WriteLine(str + " " + "Error: делитель = 0");
                            else
                                writer.WriteLine(str + " " + (resDiv1 / resDiv2));
                        }
                    }
                }
            }
        }
    }
}