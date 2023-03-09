// See https://aka.ms/new-console-template for more information
using ConsoleClient;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5123");
var client = new CustomerService.CustomerServiceClient(channel);
var request = new GetCustomersRequest();
var response = await client.GetCustomersAsync(request);
foreach (var customer in response.Customers)
{
    Console.WriteLine($"ID: {customer.ID}, CompanyName: {customer.CompanyName}, ContactName: {customer.ContactName}, ContactTitle: {customer.ContactTitle}, Address: {customer.Address}, City: {customer.City}, Region: {customer.Region}, PostalCode: {customer.PostalCode}, Country: {customer.Country}, Phone: {customer.Phone}, Fax: {customer.Fax}");
    Console.WriteLine("====================================");
}
Console.ReadLine();
