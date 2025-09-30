using SOLID.SRP.EX2.After;

namespace SOLID.SRP.EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var invoice = new Invoice
            {
                Id = 1,
                Customer = "Eslam",
                Items = new List<string> { "Item1", "Item2" }
            };

            // Choose implementation at runtime
            IInvoiceRepository repository = new DbInvoiceRepository();
            IInvoiceExporter exporter = new PdfInvoiceExporter();

            var service = new InvoiceService(repository, exporter);
            service.ProcessInvoice(invoice);
        }
    }
}
