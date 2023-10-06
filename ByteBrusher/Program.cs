using ByteBrusher.Utils.Arguments;

namespace ByteBrusher
{
    public class Program
    {
        //Set your path manually here, if you dont want to use the command argument or want to see it working in debug mode
        private readonly string _pathToCleanUp = "";

        static void Main(string[] args)
        {
            if (args.Length == 0){Console.WriteLine("Keine Argumente übergeben!");}

            Console.WriteLine("---- < Starting ByteBrusher > ----");


            Console.WriteLine("Übergebene Argumente:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Argument {i + 1}: {args[i]}");
            }

            // Beispiel: Überprüfe, ob ein spezifisches Argument übergeben wurde
            if (Array.Exists(args, arg => arg.Equals("--help", StringComparison.OrdinalIgnoreCase)))
            {
                ArgUtil.ShowHelp();
            }
        }
    }
}