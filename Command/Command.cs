using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    public abstract class Command : ICommand
    {
        public IStrategy Strategy { get; set; }
        public string[] Answers { get; set; }

        internal static ICommand CreateCommand(string input_cmd)
        {
            var args = input_cmd.Split(' ');
            bool isCmd = args.Length >= 2 && args[0].EndsWith(':');
            var cmd = args[0].Remove(args[0].Length - 1, 1);

            if (!isCmd)
                return new MessageCommand();

            Commands type;
            try
            {
                type = (Commands)Enum.Parse(typeof(Commands), cmd);
            }
            catch (System.Exception)
            {
                return new WrondCommand();
            }

            var param = input_cmd.Replace(args[0] + " ", "");

            switch (type)
            {
                case Commands.strategy:
                    {
                        return new StrategyCommand(param);
                    }
                case Commands.calculate:
                    {
                        return new CalculateCommand(param);
                    }
                default:
                    {
                        return new WrondCommand();
                    }
            }
        }

        public abstract void Execute();
    }

    public enum Commands
    {
        strategy,
        calculate
    }
}