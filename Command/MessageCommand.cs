using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
   
    public class MessageCommand : Command
    {
        public MessageCommand()
        {
        }

        public override void Execute()
        {
            System.Console.WriteLine($"БОТ: {Strategy.GetAnswer(Answers)}");
        }
    }
}