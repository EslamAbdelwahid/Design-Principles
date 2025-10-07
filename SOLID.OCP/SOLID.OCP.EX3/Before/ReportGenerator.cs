using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX3.Before
{
    public class ReportGenerator
    {
        public void GenerateReport(string reportType)
        {
            Console.WriteLine($"Generating {reportType} report...");

            string data = "";
            if (reportType == "Finance")
                data = "Finance data...";
            else if (reportType == "HR")
                data = "HR data...";
            else if (reportType == "Sales")
                data = "Sales data...";
            else
                throw new Exception("Unsupported report type!");

            string formatted = "";
            if (reportType == "Finance")
                formatted = "*** FINANCE REPORT ***\n" + data;
            else if (reportType == "HR")
                formatted = "=== HR REPORT ===\n" + data;
            else if (reportType == "Sales")
                formatted = "### SALES REPORT ###\n" + data;

            string fileName = $"{reportType}_Report.txt";
            File.WriteAllText(fileName, formatted);
            Console.WriteLine($"Report saved to {fileName}");

            Console.WriteLine($"Sending email notification for {reportType} report...");
        }
    }
}


