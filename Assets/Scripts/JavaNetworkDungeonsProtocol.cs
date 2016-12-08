using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Unity.IO.Compression;
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
        public JavaNetworkDungeonsProtocol()
        {
        }
        public void write(String s)
        {
            Debug.Log("Sending " + s);
            List<byte> listToSend = new List<byte>();
            foreach(char c in s.ToCharArray())
            {
                listToSend.Add((byte) c);
            }
            tcpSocket.Send(listToSend.ToArray());
        }
        public void processInput()
        {
            //GZipStream gZipStream = new GZipStream(new NetworkStream(tcpSocket), CompressionMode.Decompress);
            byte[] bytes = new byte[1000000];
            //Debug.Log(tcpSocket.Available);
            if(tcpSocket.Available >= 1)
            {
                Debug.Log(tcpSocket.Available);
                //int bytesRecieved = 1000000;
                int bytesRecieved = tcpSocket.Receive(bytes);
                //gZipStream.Read(bytes, 0, 1000000);
                string sInput = Encoding.ASCII.GetString(bytes, 0, bytesRecieved);
                Debug.Log("Processing input: " + sInput);
                List<String> listInputs = new List<String>();
                while (sInput.Contains("<EOF>"))
                {
                    listInputs.Add(sInput.Substring(0, sInput.IndexOf("<EOF>")));
                    sInput = sInput.Substring(sInput.IndexOf("<EOF>") + 5);
                    Debug.Log("Found EOF");
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
            this.promptWindowManager = GetComponentInChildren<PromptWindowManager>();
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
            if (s.Contains("iNumSelectable"))
            {
                Debug.Log("Recieved ListPrompt command!");
                
                ListPrompt p = JsonUtility.FromJson<ListPrompt>(s);
                promptWindowManager.PromptPopup(p);
            }
            else if (s.Contains("sPromptTitle"))
            {
                OpenPrompt p = JsonUtility.FromJson<OpenPrompt>(s);
                promptWindowManager.OpenPromptPopup(p);
            }
            if (s.Contains("currentTempDungeon"))
            {
                GetComponent<GameManager>().activeCampaign = JsonUtility.FromJson<Campaign>(s);
                Debug.Log("Making campaign from JSON");
                if (GetComponent<GameManager>().activeCampaign.currentTempDungeon == null)
                {
                    Debug.Log("Current tempDungeon is null, you have entirely failed.");
                }
                if (GetComponent<GameManager>().activeCampaign.currentTempDungeon != null)
                {
                    Debug.Log("Current tempDungeon is not null");
                }
                GetComponent<GameManager>().activeCampaign.toNormalDungeons();
                if (GetComponent<GameManager>().activeCampaign != null)
                {
                    Debug.Log("Active Campaign isn't null!");
                    //Debug.Log(GetComponent<GameManager>().activeCampaign.toString());
                }
                if (GetComponent<GameManager>().activeCampaign.currentDungeon.dungeonMap != null)
                {
                    Debug.Log("Current dungeonmap isn't null!");
                }
                if (GetComponent<GameManager>().activeCampaign.listParty != null)
                {
                    Debug.Log("listParty isn't null!");
                }
            }
            if (s.Contains("Sending Dungeon of size: "))
            {
                int size = int.Parse(s.Substring(24));
                Debug.Log(size);
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {

                    }
                }
            }
        }
    }
}