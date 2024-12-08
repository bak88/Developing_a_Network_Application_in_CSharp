using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dz4._1
{
    internal class ReceiveMessageCommand : ICommand
    {
        private static UdpClient _udpClient;
        private IPEndPoint _endPoint;
        Message MessageReceived { get; set; }


        public ReceiveMessageCommand(IPEndPoint endPoint)
        {
            _udpClient = new UdpClient(12345); // Socket for receiving messages
            _endPoint = endPoint;
        }

        public void Execute()
        {
            var data = _udpClient.Receive(ref _endPoint);
            string message = System.Text.Encoding.UTF8.GetString(data); // Преобразование байтового массива в строку
            var mess = Message.FromJson(message);
            var t = new PrototypePattern(mess);
            var messageWithConstText = (Message)t.Clone();
            Console.WriteLine(messageWithConstText.ToString());
            MessageReceived = messageWithConstText;
        }
    }
}
