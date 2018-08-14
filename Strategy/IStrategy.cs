using System;

namespace Chatb_bot.Strategy
{
    public interface IStrategy
    {
        string GetAnswer(string[] ansers);
        string ToString();
    }

    public interface ISequenceStrategy
    {
        int Pointer { get; set; }
    }

    internal class RandomStrategy : IStrategy
    {
        public RandomStrategy()
        {
        }

        public string GetAnswer(string[] ansers)
        {
            var rnd = new Random().Next(0, ansers.Length - 1);
            return ansers[rnd];
        }
        public override string ToString()
        {
            return "rand";
        }
    }

    internal class UpSeqeuenceStrategy : IStrategy, ISequenceStrategy
    {
        public int Pointer { get; set; }
        public UpSeqeuenceStrategy()
        {
            Pointer = 0;
        }
        public string GetAnswer(string[] ansers)
        {
            if (Pointer >= ansers.Length)
            {
                Pointer = 0;
            }
            return ansers[Pointer++];
        }
        public override string ToString()
        {
            return "upset";
        }
    }

    internal class DownSeqeuenceStrategy : IStrategy, ISequenceStrategy
    {
        public int Pointer { get; set; }

        public DownSeqeuenceStrategy()
        {
            Pointer = 0;
        }
        public string GetAnswer(string[] ansers)
        {
            if (Pointer == 0)
            {
                Pointer = ansers.Length - 1;
            }
            return ansers[Pointer--];
        }
        public override string ToString()
        {
            return "downseq";
        }
    }

    public static class StrategyFactory
    {
        internal static IStrategy GetStrategy(string strategyName)
        {
            switch (strategyName)
            {
                case "rand":
                    {
                        return new RandomStrategy();
                    }
                case "upseq":
                    {
                        return new UpSeqeuenceStrategy();
                    }
                case "downseq":
                    {
                        return new DownSeqeuenceStrategy();
                    }
                default:
                    {
                        return new RandomStrategy();
                    }
            }
        }
    }
}