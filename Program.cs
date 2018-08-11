using System; 
using System.Collections.Generic; 
using System.IO; 
namespace Chatb_bot {
    class Program {


        static void Main(string[] args) {
            Console.Write("Talk to me: Enter strategy and file name");
            var input = Console.ReadLine();

            var param = input.Split(" "); 
            if (param.Length != 2) {
                Console.WriteLine("Wrong input"); 
            }
            var strategyName = param[0]; 
            var fileName = param[1]; 

            if ( ! File.Exists(Path.Combine(Environment.CurrentDirectory,fileName))) {
                Console.WriteLine("Curent file does not exists"); 
                Console.ReadKey(); 
                return; 
            }
            var strategy = StrategyFactory.GetStrategy(strategyName); 

            var answers = new List < string > (); 
            string line; 
            
            // create answers list
            StreamReader file = new StreamReader(fileName); 
            // using
            while ((line = file.ReadLine()) != null) {
                answers.Add(line.Replace("> ", "")); 
            }
            file.Close();

            while (true) {
                Console.Write("BOT: "); 
                Console.WriteLine(strategy.GetAnswer(answers)); 
                Console.Write("YOU: ");
                var input_string = Console.ReadLine();
            
                if (input_string.IndexOf("calculate")!=1 ||input_string.IndexOf("strategy")!=-1) {
                    var command =  ConsoleCommand.Parse(input_string);
                }
                else{
                   Console.WriteLine("У тебя в голове мозги или кю?! "):
                }
            }
        }
    }

 
}
