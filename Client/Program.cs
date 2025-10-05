using System.Net;
using System.Net.Sockets;

namespace Client;


class Program
{
    static void Main()
    {
        var client = new TcpClient("127.0.0.1", 27001);

        var stream = client.GetStream();

        var bw = new BinaryWriter(stream);
        var br = new BinaryReader(stream);

        //////////////////////////
        ///

        // while (true)
        // {
        //     Console.WriteLine("Client to Message....");
        //     bw.Write(Console.ReadLine() ?? "Okey");
        //     Console.WriteLine($"Server answer: {br.ReadString()}");
        // }

        //////////////////////////

        var fileStream = new FileStream("SecretLove.jpg",FileMode.Create, FileAccess.Write);

        stream.CopyTo(fileStream);

        fileStream.Flush();
        fileStream.Close();

    }
}