static class SyntaxDemo
{
    /*
    public static string ToLabel(string value)
    {
        if (value.Length <= 20)
        {
            return value.PadRight(20);
        }
        return value[..17] + "...";
    }
    */

    public static string ToLabel(string value) => value switch
    {
        { Length: <= 20 } => value.PadRight(20),
        _ => value[..17] + "..."
    };

    public static void Main()
    {
        // Example of a simple syntax demonstration
        int number = 42;
        string message = "The answer is: " + number;
        Console.WriteLine(message);
    }
}