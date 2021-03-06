﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using ClassLibrary1;


namespace bookXchangeServer
{
    class Program
    {
        public static List<Listing> listOfListings = new List<Listing>();
        static void Main(string[] args)
        {
            int i = -1;
            do
            {
DataReciever.RecieveData();
                i++;
            string bookID = listOfListings[i].GetBookID();
            Console.WriteLine(bookID);
            } while (true);
            
            Console.ReadKey();
        }
        public static void DoRead()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            int port = 42004;
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(localAddr, port);
                listener.Start();
                byte[] bytes = new Byte[256];

                do
                {
                    Console.Write("Waiting for a connectioin...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Connected");

                    NetworkStream stream = client.GetStream();
                    XmlSerializer serializer = new XmlSerializer(typeof(byte[]));
                  //  IFormatter formatter = new BinaryFormatter();
                    byte[] data = (byte[])serializer.Deserialize(stream);
                    byte[] data2 = data;
                    // Console.WriteLine("Created new listing with id " + listing.GetListingID().ToString() + ". Success!");
                    client.Close();
                } while (true);


            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                listener.Stop();
            }

        }
    }
}
