using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace KSIS_3_client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Filename: ");
                string FileName = Console.ReadLine();

                UInt32 Offset;
                bool isAvailable = false;
                while (!isAvailable)
                {
                    try
                    {
                        isAvailable = true;
                        Console.Write("Offset: ");
                        Offset = UInt32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        isAvailable = false;
                        Console.WriteLine("Invalid offset. Try again.");
                    }
                }

                UInt32 BlockSize;
                isAvailable = false;
                while (!isAvailable)
                {
                    try
                    {
                        isAvailable = true;
                        Console.Write("Block Size: ");
                        BlockSize = UInt32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        isAvailable = false;
                        Console.WriteLine("Invalid Block Size. Try again.");
                    }
                }

                IPEndPoint ipEndPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 1200);
                Socket sender = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ipEndPoint);
                int bytesSent = sender.Send(new byte[] { byte.Parse(FileName)});


            }
            
        }
    }
}
