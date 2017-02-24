using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System;
using System.Threading;

namespace ServerSide{
	public static class Network_Server {
		private const int PORT = 11900;

		private static bool serverRunning = false;
		private static IPEndPoint ipEndPoint;
		private static TcpListener tcpListener;
		private static Socket serverSocket;
		private static Thread welcomeThread;

		public static void Begin() {
			Debug.Log ("Begin Network_Server");
			ClientManager.Init();
			welcomeThread = new Thread(WelcomeConnection);
			welcomeThread.Start();
		}


		private static void WelcomeConnection() {
			ipEndPoint = new IPEndPoint(IPAddress.Any, PORT);
			tcpListener = new TcpListener(ipEndPoint);

			tcpListener.Start();

			serverRunning = true;
			while (serverRunning) {
				Debug.Log("Ready");
				try {
					Socket welcomeSocket = tcpListener.AcceptSocket();
					if(ClientManager.AddClient(welcomeSocket))
						Debug.Log("connected");
					else
						Debug.Log("Server is Full");
				}
				catch (Exception e){
					Debug.Log(e.Message);
					break;
				}
			}

			Debug.Log ("Welcome Dead");
		}
			
		public static void ShutDown() {
			serverRunning = false;

			ClientManager.ShutDown();
			if(welcomeThread != null) {
				tcpListener.Stop();
			}
		}
		public static void Brodcast(string str) {
			ClientManager.BroadCast (str);
		}

	}
}
