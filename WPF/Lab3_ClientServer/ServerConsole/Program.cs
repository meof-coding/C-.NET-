using System.Net.Sockets;
using System.Net;
using ServerConsole.Entity;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

int count = 0;
string host = "127.0.0.1";
int port = 1500;
Console.WriteLine("Server App");
IPAddress localAddr = IPAddress.Parse(host);
TcpListener server = new TcpListener(localAddr, port);
server.Start();

Console.WriteLine("************************");
Console.WriteLine("waiting....");

while (true)
{
    TcpClient client = server.AcceptTcpClient();
    Console.Write("*************************");
    Console.WriteLine($"Number of client connected: {++count}");
    Thread thread = new Thread(new ParameterizedThreadStart(ProcessClient));
    thread.Start(client);
}

static void ProcessClient(object parameter)
{
    NorthwindContext context = new NorthwindContext();

    TcpClient client = (TcpClient)parameter;
    string data;
    int count;
    NetworkStream stream = client.GetStream();
    Byte[] bytes = new Byte[1024];
    while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
    {
        data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
        string[] words = data.Split('/');
        switch (words[0])
        {
            case "getById":
                context = new NorthwindContext();

                String id = words[1];

                Product product = context.Products.FirstOrDefault(p => p.ProductId == Int32.Parse(id));
                String jsonProduct = Newtonsoft.Json.JsonConvert.SerializeObject(product);

                //logic request -> respone.
                Byte[] msg1 = System.Text.Encoding.ASCII.GetBytes(jsonProduct);
                stream.Write(msg1, 0, msg1.Length);
                break;
            case "getAllProduct":
                context = new NorthwindContext();

                List<Product> products = context.Products.ToList();
                String jsonProducts = Newtonsoft.Json.JsonConvert.SerializeObject(products);

                //logic request -> respone.
                Byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(jsonProducts);
                stream.Write(msg2, 0, msg2.Length);
                break;
            case "addProduct":
                context = new NorthwindContext();

                string requestDataAdd = words[1];

                Product addPro = JsonConvert.DeserializeObject<Product>(requestDataAdd);
                context.Products.Add(addPro);
                context.SaveChanges();

                //logic request -> respone.
                Byte[] msg3 = System.Text.Encoding.ASCII.GetBytes("Success");
                stream.Write(msg3, 0, msg3.Length);
                break;
            case "updateProduct":
                context = new NorthwindContext();

                string requestDataUpdate = words[1];

                Product updatePro = JsonConvert.DeserializeObject<Product>(requestDataUpdate);
                context.Entry<Product>(updatePro).State = EntityState.Modified;
                context.SaveChanges();

                //logic request -> respone.
                Byte[] msg4 = System.Text.Encoding.ASCII.GetBytes("Success");
                stream.Write(msg4, 0, msg4.Length);
                break;
            case "deleteProduct":
                context = new NorthwindContext();
                string requestDataDelete = words[1];

                int deleteId = Int32.Parse(requestDataDelete);

                List<OrderDetail> orderDetails = context.OrderDetails.Where(od => od.ProductId == deleteId).ToList();
                context.OrderDetails.RemoveRange(orderDetails);

                Product deleteProduct = context.Products.FirstOrDefault(p => p.ProductId == deleteId);
                context.Products.Remove(deleteProduct);

                context.SaveChanges();

                //logic request -> respone.
                Byte[] msg5 = System.Text.Encoding.ASCII.GetBytes("Success");
                stream.Write(msg5, 0, msg5.Length);
                break;
            case "importProduct":
                context = new NorthwindContext();
                string importJSON = words[1];

                List<Product> importProducts = JsonConvert.DeserializeObject<List<Product>>(importJSON);

                foreach (var p in importProducts)
                {
                    p.ProductId = 0;

                    context.Products.Add(p);
                    context.SaveChanges();
                }

                //logic request -> respone.
                Byte[] msg6 = System.Text.Encoding.ASCII.GetBytes("Success");
                stream.Write(msg6, 0, msg6.Length);
                break;
        }
    }
    client.Close();
}