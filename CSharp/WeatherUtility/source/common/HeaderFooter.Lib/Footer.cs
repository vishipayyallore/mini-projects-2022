using HeaderFooter.Lib.Interfaces;

using static System.Console;

namespace HeaderFooter.Lib
{

    public class Footer : IFooter
    {

        public void DisplayFooter(char footer, int length = 100)
        {
            WriteLine($"\n{new string(footer, length)}\n");
        }

    }

}
