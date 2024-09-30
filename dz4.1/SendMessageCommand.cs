using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dz4._1
{
    internal class SendMessageCommand : ICommand
    {
        private string _message;
        private IPEndPoint _endPoint;
        private DateTime _dateTime;
        private string _fromName;

        public SendMessageCommand(string message, IPEndPoint endPoint, DateTime dateTime, string fromName)
        {
            _message = message;
            _endPoint = endPoint;
            _dateTime = dateTime;
            _fromName = fromName;
        }

        public void Execute()
        {
            UdpClient udpClient = new UdpClient(12345); // Socket for sending messages

            Message message = new Message() { dateTime = _dateTime, FromName = _fromName, Text = _message };

            PrototypePattern text = new PrototypePattern(message);                      // Prototype pattern
            var messageWithConstantText = (Message)text.Clone();
            var messageJson = messageWithConstantText.ToJson();
            byte[] messageBytes = Encoding.UTF8.GetBytes(messageJson);
            udpClient.Send(messageBytes, messageBytes.Length, _endPoint);

            Console.WriteLine("Message sent via UDP.");
        }
    }
}
