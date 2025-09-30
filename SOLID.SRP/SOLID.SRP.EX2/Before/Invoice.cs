using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP.EX2.Before
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<string> Items { get; set; }
        public decimal Total { get; set; }

        // 1. Business logic
        public void CalculateTotal()
        {
            Total = Items.Sum(item => GetPrice(item));
        }

        private decimal GetPrice(string item)
        {
            // return item price
            return 100; // simplified
        }

        // 2. Persistence
        public void SaveToDatabase()
        {
            Console.WriteLine("Saving invoice to DB...");
            // code to insert into database
        }

        // 3. Reporting / Export
        public void ExportToPdf()
        {
            Console.WriteLine("Exporting invoice to PDF...");
            // code to generate PDF
        }
    }

}
