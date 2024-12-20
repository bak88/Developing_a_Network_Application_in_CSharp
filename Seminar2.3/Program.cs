﻿using System;

namespace Seminar2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server.AcceptMessage();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    new Thread(() =>
                    {
                        Client.SendMessage($"{args[0]} {i}");
                    }).Start();

                }
            }
        }
    }
}
