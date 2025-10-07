using SOLID.OCP.EX3.After;

namespace SOLID.OCP.EX3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileSaver = new FileSaver();
            var notifier = new EmailNotifier();
            var generator = new ReportGenerator(fileSaver, notifier);

            IReport report = new FinanceReport(); // you can replace with HRReport, SalesReport, etc.
            generator.Generate(report);
        }
    }
}
