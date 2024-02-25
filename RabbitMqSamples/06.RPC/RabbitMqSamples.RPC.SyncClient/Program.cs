using RabbitMqSamples.RPC.SyncClient.Models;

CustomerCaller customerCaller = new CustomerCaller();

bool getAnotherCustomer = false;
do
{
    Console.WriteLine("Enter Customer Id: ");
    int customerId = int.Parse(Console.ReadLine());

    var customer = customerCaller.Get(customerId);

    Console.WriteLine($"CustomerId: {customer.CustomerId}\tCustomer Name:{customer.Name}\tCustomer Family:{customer.Family}");

    Console.WriteLine("Continue?y/n: ");
    var input = Console.ReadLine();
    getAnotherCustomer = input=="y";
}while (getAnotherCustomer);

customerCaller.CloseConnection();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();