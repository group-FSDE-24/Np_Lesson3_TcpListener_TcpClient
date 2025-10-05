using System.Net;
using System.Net.Sockets;

namespace Server;

class Program
{
    static void Main()
    {
        var ip = IPAddress.Parse("127.0.0.1");
        var port = 27001;

        TcpListener tcpListener = new TcpListener(ip, port);

        tcpListener.Start(10);

        Console.WriteLine($"{tcpListener.Server.LocalEndPoint} listening.....");

        var client = tcpListener.AcceptTcpClient();

        Console.WriteLine($"{client.Client.RemoteEndPoint} connected server....");


        var stream = client.GetStream();

        var br = new BinaryReader(stream);
        var bw = new BinaryWriter(stream);


        while (true)
        {
            Console.WriteLine(br.ReadString());
            bw.Write("Good Message");
        }

    }
}