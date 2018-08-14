using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    public class StrategyCommand : Command
    {
        private string name;
        public StrategyCommand(string param)
        {
            this.name = param;
        }
        public override void Execute()
        {
            Strategy = StrategyFactory.GetStrategy(name);
            Console.WriteLine($"Как советовать так все чатлане. Использую стратегию: {Strategy}");
        }
    }
}