using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    public class WrondCommand : Command
    {
        public WrondCommand()
        {

        }
        public override void Execute()
        {
            System.Console.WriteLine("У тебя у голове мозги или кю?");
        }
    }
}