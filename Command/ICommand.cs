public abstract class Command{
    string Action{get;set;}
    string Argument{get;set;}
public static Command Parse(string input){
    if  (input.IndexOf("calculate")!=1 ||input.IndexOf("strategy")!=-1){
        var param = input.Split(":");
        return new ConsoleCommand(param[0],param[1]);
    }
    return null;
}
}
public class ConsoleCommand:Command{
public ConsoleCommand(string action, string argument)
{
    
}

}