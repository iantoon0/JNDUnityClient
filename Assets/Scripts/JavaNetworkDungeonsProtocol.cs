using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts
{
    public class JavaNetworkDungeonsProtocol: MonoBehaviour
    {
        public Boolean bHasPrompt;
        public Socket tcpSocket;
        PromptWindowManager promptWindowManager;
        // ManualResetEvent instances signal completion.
        private const int port = 555;
        int iterator = 0;
        public JavaNetworkDungeonsProtocol(PromptWindowManager promptWindowManager)
        {
            this.promptWindowManager = promptWindowManager;
        }
        public void write(String s)
        {
            List<byte> listToSend = new List<byte>();
            foreach(char c in s.ToCharArray())
            {
                listToSend.Add((byte) c);
            }
            tcpSocket.Send(listToSend.ToArray());
        }
        public void processInput()
        {
            byte[] bytes = new byte[8192];
            Debug.Log(tcpSocket.Available);
            if(tcpSocket.Available >= 1)
            {

                Debug.Log("Created bytes, recieving from TCPSocket");
                int bytesRec = tcpSocket.Receive(bytes);
                Debug.Log("Bytes: " + bytes);
                string sInput = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Debug.Log("Processing input: " + sInput);
                List<String> listInputs = new List<String>();
                while (sInput.Contains("<EOF>"))
                {
                    listInputs.Add(sInput.Substring(0, sInput.IndexOf("<EOF>")));
                    sInput = sInput.Substring(sInput.IndexOf("<EOF>") + 5);
                }
                foreach (String s in listInputs)
                {
                    processInput(s);
                }
            }
        }
        public void connect(String sAddress)
        {
            Debug.Log("Subbmitted " + sAddress + " to jndp.connect");
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Connect(IPAddress.Parse(sAddress), port);
        }
        public void update()
        {
            iterator++;
            if(iterator == 50 && tcpSocket != null)
            {
                processInput();
                iterator = 0;
            }
            if(iterator == 50)
            {
                iterator = 0;
            }
        }
        public void processInput(string s)
        {
            if (s.Contains("sPromptTitle"))
            {
                Debug.Log("Recieved prompt command!");
                Prompt p = JsonUtility.FromJson<Prompt>(s);
                promptWindowManager.PromptPopup(p);
            }
            if (s.Contains("listParty"))
            {
                GetComponent<GameManager>().activeCampaign = JsonUtility.FromJson<Campaign>(s);
            }
        }
    }
}