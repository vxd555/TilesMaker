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

        List<UInt32> dumpImage;
        Byte[] dumpBytes;
        bool dumpLock = false;

        bool isServer = false;

        private unsafe void DumpImageToList()
        {
            dumpLock = true;

            dumpImage = new List<UInt32>();
            dumpImage.Add((uint)globalSize);

            BitmapData bmSrc = sourcePicture.LockBits(new Rectangle(Point.Empty, sourcePicture.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            UInt32* ptrSrc = (UInt32*)bmSrc.Scan0.ToPointer();

            for(int px = 0; px < globalSize; ++px)
            {
                for (int py = 0; py < globalSize; ++py)
                {
                    dumpImage.Add(*(ptrSrc + px + sourcePicture.Width * py));
                }
            }

            sourcePicture.UnlockBits(bmSrc);
            dumpLock = false;

            dumpBytes = dumpImage.SelectMany(BitConverter.GetBytes).ToArray();
        }

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

            DEBUG.Text = IPAdress.Text; //spisywanie adresu aby użytkownik widział

            HostButton.Visible = false;
            ConnectButton.Visible = false;
            IPAdress.Visible = false;
            IPLabel.Visible = false;

            serverSocket.Listen(0);

            isServer = true;

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
                    DEBUG.Text = "accept connection";

                    buttonSend.Enabled = true;
                }
                else
                {
                    if (clientAmount == 0)
                    {
                        byte[] buffer = Encoding.Default.GetBytes("connection complete");
                        clientSockets[clientAmount].Send(buffer, 0, buffer.Length, 0);
                        ++clientAmount;
                    }

                    byte[] recived = new byte[16388];

                    for (int i = 0; i < clientSockets.Count; ++i)
                    {
                        int rec = clientSockets[i].Receive(recived, 0, recived.Length, 0);
                        Array.Resize(ref recived, rec);

                        if (rec > 0)
                        {
                            DEBUG.Text = Encoding.Default.GetString(recived);
                            if (rec < 50) //komunikaty
                            {
                                DEBUG.Text = Encoding.Default.GetString(recived);
                            }
                            else
                            {
                                dumpImage = new List<UInt32>();
                                for (int el = 0; el < recived.Length / 4; ++el)
                                {
                                    byte[] byteImage = { recived[el * 4 + 0], recived[el * 4 + 1], recived[el * 4 + 2], recived[el * 4 + 3] };
                                    dumpImage.Add(BitConverter.ToUInt32(byteImage, 0));
                                }

                                DrawPixelFromColorList(dumpImage);
                            }
                        }

                        rec = 0;
                    }

                }
            }
        }

        public void SendImage()
        {
            if(isServer)
            {
                DumpImageToList();
                clientSockets[0].Send(dumpBytes, 0, dumpBytes.Length, 0);
            }
            else
            {
                DumpImageToList();
                serverSocket.Send(dumpBytes, 0, dumpBytes.Length, 0);
            }

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendImage();
        }

        //pętla klienta odpowiedzialna za odbieranie
        private void ClientLoop()
        {
            buttonSend.Enabled = true;
            for (; ; )
            {
                byte[] recived = new byte[16388]; //16388

                int rec = serverSocket.Receive(recived, 0, recived.Length, 0);
                Array.Resize(ref recived, rec);

                if (rec > 0)
                {
                    if(rec < 50) //komunikaty
                    {
                        DEBUG.Text = Encoding.Default.GetString(recived);

                        HostButton.Visible = false;
                        ConnectButton.Visible = false;
                        IPAdress.Visible = false;
                        IPLabel.Visible = false;
                    }
                    else
                    {
                        dumpImage = new List<UInt32>();
                        for(int el = 0; el < recived.Length / 4; ++el)
                        {
                            byte[] byteImage = {recived[el * 4 + 0], recived[el * 4 + 1], recived[el * 4 + 2], recived[el * 4 + 3]};
                            dumpImage.Add(BitConverter.ToUInt32(byteImage, 0));
                        }

                        DrawPixelFromColorList(dumpImage);
                    }
                    
                }
                rec = 0;

            }
        }
    }

}