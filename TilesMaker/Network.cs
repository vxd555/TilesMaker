using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace TilesMaker
{
    public partial class TilesMaker : Form
    {
        //obsługa sieci
        Socket serverSocket;
        List<Socket> clientSockets;
        Thread serverThread;
        Thread clientThread;
        int clientAmount;

        //gdy kilkniemy button połącz
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IPAdress.Text), 1338);
            serverSocket.Connect(endPoint);

            clientThread = new Thread(ClientLoop);
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        //gdy klikniemy przycisk do tworzenia serwera
        private void HostButton_Click(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress tempAddress = IPAddress.Parse(IPAdress.Text); //stwworzenie z adresu 
            serverSocket.Bind(new IPEndPoint(tempAddress, 1338));

            ConnectionInfo.Text = IPAdress.Text; //spisywanie adresu aby użytkownik widział

            serverSocket.Listen(0);

            serverThread = new Thread(ServerLoop);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        //główna pętla serwera odpowiedzialna za łączenie użytkowików oraz wysyłanie informacji
        private void ServerLoop()
        {
            for (; ; )
            {
                if (clientSockets.Count == 0)
                {
                    Socket tempsoc = null;
                    tempsoc = serverSocket.Accept();
                    clientSockets.Add(tempsoc);
                    ConnectionInfo.Text = "accept";
                }
                else
                {
                    if (clientAmount == 0)
                    {
                        byte[] buffer = Encoding.Default.GetBytes("connect is complite");
                        clientSockets[clientAmount].Send(buffer, 0, buffer.Length, 0);
                        ++clientAmount;
                    }

                    byte[] recived = new byte[255];

                    for (int i = 0; i < clientSockets.Count; ++i)
                    {
                        int rec = clientSockets[i].Receive(recived, 0, recived.Length, 0);
                        Array.Resize(ref recived, rec);

                        if (rec > 0)
                        {
                            ConnectionInfo.Text = Encoding.Default.GetString(recived);
                        }

                        rec = 0;
                    }

                }
            }
        }

        //pętla klienta odpowiedzialna za odbieranie
        private void ClientLoop()
        {
            for (; ; )
            {
                byte[] recived = new byte[255];

                int rec = serverSocket.Receive(recived, 0, recived.Length, 0);
                Array.Resize(ref recived, rec);

                if (rec > 0)
                {
                    ConnectionInfo.Text = Encoding.Default.GetString(recived);
                }

                rec = 0;

            }
        }
    }

}