// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


do
{
    Console.Clear();
    Console.Write("Enter the Amount: ");
    decimal amount = decimal.Parse(Console.ReadLine());
    Console.Write("\nEnter the Method: ");
    string method = Console.ReadLine(); 

    var paymentService = new KissYagniTDV1.Service.PaymentService();

    var receipt = paymentService.ProcessPayment(amount, method);

    Console.WriteLine(receipt);

    Console.WriteLine("Press any key, to continue...");
    Console.ReadKey();

} while (true);
