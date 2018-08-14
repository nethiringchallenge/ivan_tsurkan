using Chatb_bot.Strategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Chatb_bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategyName = GetParam(args, "-r");
            var fileName = GetParam(args, "-f");

            IStrategy strategy = StrategyFactory.GetStrategy(strategyName);
            string[] answers = GetAnswers(fileName);

            new Chat(strategy, answers).Start();
        }

        private static string GetParam(string[] args, string param)
        {
            var index =  args.ToList().IndexOf(param) + 1;
            return args[index];
        }

        private static string[] GetAnswers(string fileName)
        {
            var lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, fileName));
            return lines.Select(x => x.Replace(">", string.Empty).Trim()).ToArray();
        }
    }
}
