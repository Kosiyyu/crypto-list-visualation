using CryptoConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        List<CryptoDto> list = Task.Run(async () => await DataFetcher.Fetch()).GetAwaiter().GetResult();

        foreach (CryptoDto i in list)
        {
            Console.WriteLine(i);
        }
    }

/*    static async Task Main(string[] args)
    {
        var list = await DataFetcher.Fetch();

        foreach (var item in list)
        {
            Console.WriteLine(item.At);
        }

        // do other stuff...
    }*/
}