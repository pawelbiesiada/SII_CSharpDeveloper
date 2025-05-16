using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Samples.SOLID
{
    public class WrongReport
    {
        public string Generate() => "Report content";

        public void SaveToFile(string content)
        {
            Console.WriteLine($"Zapisuję tekst '{content}' do pliku");
        }
    }

    public class Report
    {
        public string Generate() => "Report content";
    }

    public class ReportSaver
    {
        public void SaveToFile(string content)
        {
            Console.WriteLine($"Zapisuję tekst '{content}' do pliku");
        }
    }
}
