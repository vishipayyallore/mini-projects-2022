using HeaderFooter.Lib.Interfaces;

using static System.Console;

namespace HeaderFooter.Lib
{

    public class Header : IHeader
    {

        public void DisplayHeader(char header, string title, int length = 100)
        {
            var leftPadValue = ((length - title.Length) / 2) + title.Length;
            string headerValue = new(header, length);

            WriteLine($"\n\n{headerValue}");
            WriteLine(title.PadLeft(leftPadValue));
            WriteLine($"{headerValue}\n");
        }

    }

}