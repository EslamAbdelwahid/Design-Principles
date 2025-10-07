using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX3.After
{
    public interface IReport
    {
        string GetData();
        string FormatReport(string data);
        string GetFileName();
    }
    public class FinanceReport : IReport
    {
        public string FormatReport(string data) => $"*** FINANCE REPORT ***\n{data}";

        public string GetData() => "Finance data...";

        public string GetFileName() => "Finance_Report.txt";
    }

    public class HRReport : IReport
    {
        public string GetData() => "HR data...";

        public string FormatReport(string data) => $"=== HR REPORT ===\n{data}";

        public string GetFileName() => "HR_Report.txt";
    }

    public class SalesReport : IReport
    {
        public string GetData() => "Sales data...";

        public string FormatReport(string data) => $"### SALES REPORT ###\n{data}";

        public string GetFileName() => "Sales_Report.txt";
    }

    public interface IReportSaver
    {
        void Save(string formattedData, string fileName);
    }
    public class FileSaver : IReportSaver
    {
        public void Save(string formattedData, string fileName)
        {
            File.WriteAllText(fileName, formattedData);
            Console.WriteLine($"Report saved to {fileName}");
        }
    }
    public interface INotifier
    {
        void Notify(string reportName);
    }

    public class EmailNotifier : INotifier
    {
        public void Notify(string reportName)
        {
            Console.WriteLine($"Sending email notification for {reportName} report...");
        }
    }

    public class ReportGenerator
    {
        private readonly IReportSaver reportSaver;
        private readonly INotifier notifier;

        public ReportGenerator( IReportSaver reportSaver, INotifier notifier)
        {
            this.reportSaver = reportSaver;
            this.notifier = notifier;
        }
        public void Generate(IReport report)
        {
            Console.WriteLine($"Generating {report.GetType()} report...");

            var data = report.GetData();
            var formatted = report.FormatReport(data);

            string fileName = report.GetFileName();

            reportSaver.Save(formatted, fileName);

            notifier.Notify(report.GetType().Name);
        }
    }
}


