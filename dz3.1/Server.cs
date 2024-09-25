using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.Eventing.Reader;

namespace dz3._1
{
    internal class Server
    {
        private static bool exitRequested = false;
        
        public static async Task GetMessage()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(8080);

            Console.WriteLine("Server started");

            Task exitTask = Task.Run(() =>
            {

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    exitRequested = true;
            });


            while (!exitRequested)
            {

                await Task.Run(async () =>
                {
                    var data = udpClient.Receive(ref ep);
                    string message = System.Text.Encoding.UTF8.GetString(data);

                    User? user = User.FromJson(message);


                    if (user.IsCancelled)
                    {
                        try
                        {
                            user.CancellationTokenSource.Token.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException ex)
                        {
                            Console.WriteLine(ex.Message);
                            udpClient.Close();
                            exitRequested = true;

                        }


                    }
                    else
                    {
                        Console.WriteLine(user.ToString());

                        User response = new User("Admin", " Server accepted your message");
                        var jsonToSend = response.ToJson();
                        await udpClient.SendAsync(System.Text.Encoding.UTF8.GetBytes(jsonToSend), jsonToSend.Length, ep);
                    }

                });
            }

            exitTask.Wait();
        }
    }
}
