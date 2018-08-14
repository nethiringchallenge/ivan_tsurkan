using System;
using Chatb_bot.Strategy;

namespace Chatb_bot
{
    interface ICommand
    {
        IStrategy Strategy { get; set; }
        string[] Answers { get; set; }
        void Execute();
    }
}