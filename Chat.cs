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
            Console.WriteLine("БОТ: Как дела на плюке?");

            while (true)
            {
                System.Console.Write("Я: ");
                var input_cmd = Console.ReadLine();

                if (input_cmd == "q")
                    return;

                var cmd = Command.CreateCommand(input_cmd);
                cmd.Strategy = Strategy;
                cmd.Answers = Answers;
                cmd.Execute();

                // replace strategy, is needed only for strategy command
                Strategy = cmd.Strategy;
            }
        }
    }
}