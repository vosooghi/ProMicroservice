using RabbitMqSamples.RPC.AsyncClient.Models;


CustomerCaller customerCaller = new CustomerCaller(PrintCustomer);

bool getAnotherCustomer = false;
do
{
    Console.WriteLine("Enter Customer Id: ");
    int customerId = int.Parse(Console.ReadLine());

    customerCaller.Get(customerId);    

    Console.WriteLine("Continue?y/n: ");
    var input = Console.ReadLine();
    getAnotherCustomer = input == "y";
} while (getAnotherCustomer);

customerCaller.CloseConnection();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

void PrintCustomer(Customer customer)
{
    Console.WriteLine($"CustomerId: {customer.CustomerId}\tCustomer Name:{customer.Name}\tCustomer Family:{customer.Family}");
}