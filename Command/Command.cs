using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    public abstract class Command : ICommand
    {
        private const char cmdSeparator = ':';
        private const char charEmptySpace = ' ';
        public IStrategy Strategy { get; set; }
        public string[] Answers { get; set; }

        internal static ICommand CreateCommand(string input_cmd)
        {
            var args = input_cmd.Split(charEmptySpace);
            bool isCmd = args.Length >= 2 && args[0].EndsWith(cmdSeparator);

            if (!isCmd)
                return new MessageCommand();

            var cmd = args[0].Remove(args[0].Length - 1, 1);

            Commands cmdType;
            bool res = Enum.TryParse<Commands>(cmd, out cmdType);

            if (!res)
                return new WrondCommand();

            var param = input_cmd.Remove(0, args[0].Length + 1);

            return GetCommand(cmdType, param);
        }

        private static ICommand GetCommand(Commands cmdType, string param)
        {
            switch (cmdType)
            {
                case Commands.Strategy:
                    {
                        return new StrategyCommand(param);
                    }
                case Commands.Calculate:
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
        Strategy,
        Calculate
    }
}