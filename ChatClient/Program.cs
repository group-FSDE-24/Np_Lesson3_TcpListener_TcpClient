using System.Net.Sockets;

namespace ChatClient;


class Program
{
    static void Main()
    {
        var client = new TcpClient("10.1.18.1", 27001);

        var serverStream = client.GetStream();

        var br = new BinaryReader(serverStream);
        var bw = new BinaryWriter(serverStream);



        Task.Run(() =>
        {
            while (true)
            {
                Console.WriteLine(br.ReadString());
            }
        });



        while (true)
        {
            bw.Write(Console.ReadLine() ?? "Okey");
        }






    }
}