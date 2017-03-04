using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLibrary1;

namespace bookXchangeServer
{
    class DataReciever
    {
        public static void RecieveData()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localAddr,9050);

            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream strm = client.GetStream();
            IFormatter formatter = new BinaryFormatter();

            Listing l = (Listing)formatter.Deserialize(strm); // you have to cast the deserialized object 
            Program.listOfListings.Add(l);

            //Console.WriteLine("Hi, I'm " + p.FirstName + " " + p.LastName + " and I'm " + p.age + " years old!");

            strm.Close();
            client.Close();
            server.Stop();
        }
    }
}
