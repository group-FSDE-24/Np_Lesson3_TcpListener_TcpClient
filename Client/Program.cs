using System.Net;
using System.Net.Sockets;

namespace Client;


class Program
{
    static void Main()
    {
        var client = new TcpClient("127.0.0.1", 27001);

        var stream = client.GetStream();

        var sw = new StreamWriter(stream);
        var sr = new StreamReader(stream);


        while (true)
        {
            Console.WriteLine("Client to Message....");
            sw.Write(Console.ReadLine());
            Console.WriteLine($"Server answer: {sr.ReadToEnd()}");
        }




    }
}