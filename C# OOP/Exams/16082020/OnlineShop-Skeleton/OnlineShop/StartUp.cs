using System.IO;
using OnlineShop.Core;
using OnlineShop.IO;
using OnlineShop.Models.Products.Computers;

namespace OnlineShop
{
    public class StartUp
    {
        static void Main()
        {
            //Computer computer = new Computer(100, "sad", "das", 200m, 1.25);
            //System.Console.WriteLine(computer.OverallPerformance);

            // Clears output.txt file
            string pathFile = Path.Combine("..", "..", "..", "output.txt");
            File.Create(pathFile).Close();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IController controller = new Controller();

            IEngine engine = new Engine(reader, writer, commandInterpreter, controller);
            engine.Run();
        }
    }
}
