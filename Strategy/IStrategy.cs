using System;
using System.Collections.Generic;

public interface IStrategy {
    string GetAnswer(List<string> ansers); 
}
internal class RandomStrategy:IStrategy {
    public string GetAnswer(List<string> ansers) {
        var rnd = new Random().Next(0, ansers.Count); 
        return ansers[rnd]; 
    }
}

public interface ISequenceStrategy {
    int Pointer {get; set; }
}
internal class UpSeqeuenceStrategy:IStrategy, ISequenceStrategy {
public int Pointer {get; set; }
    public UpSeqeuenceStrategy() {
        Pointer = 0; 
    }
    public string GetAnswer(List<string> ansers) {
       return ansers[Pointer++]; 
       if (Pointer == ansers.Count) {
           Pointer = 0; 
       }
    }
}
internal class DownSeqeuenceStrategy:IStrategy, ISequenceStrategy {
public int Pointer {get; set; }
    
    public DownSeqeuenceStrategy() {
        Pointer = 0; 
    }
    public string GetAnswer(List<string> ansers) {
       return ansers[Pointer--]; 
       if (Pointer == 0) {
           Pointer = ansers.Count; 
       }
    }
}
        public static class StrategyFactory {
            internal static IStrategy GetStrategy(string strategyName) {
               if (string.IsNullOrEmpty(strategyName)) {
                   throw new ArgumentException("Wrond strategy name"); 
               }
               switch (strategyName) {
                   case "rand": {
                        return new RandomStrategy(); 
                   }
                   case "upseq":{
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