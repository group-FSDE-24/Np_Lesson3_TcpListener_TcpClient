using System.Net;
using System.Net.Sockets;

namespace ChatServer;


class Program
{
    static void Main()
    {
        var clients = new HashSet<TcpClient>();

        var ip = IPAddress.Parse("10.1.18.1");
        var port = 27001;

        var tcpListener = new TcpListener(ip, port);

        tcpListener.Start(10);

        while (true)
        {
            Console.WriteLine($"{tcpListener.Server.LocalEndPoint} listening.....");

            var client = tcpListener.AcceptTcpClient();

            Console.WriteLine($"{client.Client.RemoteEndPoint} connected server....");
            clients.Add(client);

            Task.Run(() =>
            {
                var clientStream = client.GetStream();

                var br = new BinaryReader(clientStream);

                var readString = string.Empty;


                var userIpEndPoint = string.Empty;

                var index = 0;

                // 127.0.0.1:4567 Ayan salam necesen
                while (true)
                {
                    readString = br.ReadString();
                    
                    Console.WriteLine($"{clientStream.Socket.RemoteEndPoint} - {readString}");

                    index = readString.IndexOf(' ');

                    userIpEndPoint = readString.Substring(0, index); // 127.0.0.1:4567

                    var destination = clients.FirstOrDefault(x => x.Client.RemoteEndPoint?.ToString() == userIpEndPoint); // 


                    var bw = new BinaryWriter(destination!.GetStream());

                    bw.Write($"{clientStream.Socket.RemoteEndPoint} - {readString.Substring(index + 1)}");
                }

            });

        }

    }
}