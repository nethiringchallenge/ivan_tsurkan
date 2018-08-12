using System;
using System.Collections.Generic;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    internal class Chat
    {
        private IStrategy Strategy;
        private string[] Answers;

        public Chat(IStrategy strategy, string[] answers)
        {
            this.Strategy = strategy;
            this.Answers = answers;
        }

        internal void Start()
        {
            Console.WriteLine("BOT: Как дела на плюке?");

            while (true)
            {
                Console.Write("I: ");
                var input_string = Console.ReadLine();

                if (input_string == "q")
                    return;

                if (input_string.StartsWith("strategy: "))
                    ChangeStrategy(input_string);

                ChatMessage();
            }
        }

        private void ChatMessage()
        {
            Console.Write("BOT: ");
            Console.WriteLine(Strategy.GetAnswer(Answers));
        }

        public void ChangeStrategy(string command)
        {
            var strategyName = command.Split(":")[1].Trim();
            Strategy = Program.GetStrategy(strategyName);

            Console.WriteLine("Как советовать так все чатлане. Использую стратегию: " + Strategy.ToString());
        }
    }
}