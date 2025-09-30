using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP.EX2.After
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<string> Items { get; set; }
        public decimal Total { get; private set; }

        public void CalculateTotal()
        {
            Total = Items.Sum(item => GetPrice(item));
        }

        private decimal GetPrice(string item)
        {
            // Simulate price lookup
            return 100; 
        }
    }
    public interface IInvoiceRepository
    {
        void Save(Invoice invoice);
    }

    public class DbInvoiceRepository : IInvoiceRepository
    {
        public void Save(Invoice invoice)
        {
            Console.WriteLine($"Saving invoice {invoice.Id} for {invoice.Customer} to the database...");
        }
    }

    public interface IInvoiceExporter
    {
        void Export(Invoice invoice);
    }

    public class PdfInvoiceExporter : IInvoiceExporter
    {
        public void Export(Invoice invoice)
        {
            Console.WriteLine($"Exporting invoice {invoice.Id} for {invoice.Customer} to PDF...");
        }
    }

    public class ExcelInvoiceExporter : IInvoiceExporter
    {
        public void Export(Invoice invoice)
        {
            Console.WriteLine($"Exporting invoice {invoice.Id} for {invoice.Customer} to Excel...");
        }
    }

    public class InvoiceService
    {
        private readonly IInvoiceRepository repository;
        private readonly IInvoiceExporter exporter;

        public InvoiceService(IInvoiceRepository repository, IInvoiceExporter exporter)
        {
            this.repository = repository;
            this.exporter = exporter;
        }

        public void ProcessInvoice(Invoice invoice)
        {
            invoice.CalculateTotal();
            repository.Save(invoice);
            exporter.Export(invoice);
        }
    }

}
