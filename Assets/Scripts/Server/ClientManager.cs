using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;

namespace ServerSide{
	public static class ClientManager {		
		private const int maxClientCount = 10;

		private static TcpConnection[] arrayClient;
		public static TcpConnection getClient(int idx){
			return arrayClient[idx];
		}
		private static Queue<int> freeQueue;
		public static Int32 ClientCount{
			get{
				return freeQueue.Count;
			}
		}

		public static void Init(){
			freeQueue = new Queue<int>();
			for(int loop = 0; loop < maxClientCount; loop++){
				freeQueue.Enqueue(loop);
			}

			arrayClient = new TcpConnection[maxClientCount];
		}

		public static bool AddClient(Socket welcomeSocket_){
			int freeId = GetFreeId();

			if(freeId == -1){
				welcomeSocket_.Disconnect(false);
				return false;
			}else{
				arrayClient[freeId] = new TcpConnection(welcomeSocket_, freeId);

				return true;
			}
		}


		public static void BroadCast(string nm_){
			if(arrayClient == null)return;


			for(int loop = 0; loop < maxClientCount; loop++){
				if(arrayClient[loop] != null){
					if (arrayClient [loop].IsConnected) {						
						arrayClient [loop].Send (nm_);
					}
				}
			}
		}

		/*
		public static void BroadCast(NetworkMessage nm_, int exclude_){
			if(arrayClient == null)return;


			for(int loop = 0; loop < NetworkConst.maxPlayer; loop++){
				if(loop == exclude_)continue;

				if(arrayClient[loop] != null){
					if (arrayClient [loop].IsConnected) {
						nm_.Adress.Content = loop.ToString ();
						arrayClient [loop].Send (nm_.ToString ());
					}
				}
			}
		}

		public static void UniCast(int targetId_, NetworkMessage nm_){
			if(arrayClient[targetId_] != null){
				if(arrayClient[targetId_].IsConnected)
					arrayClient[targetId_].Send(nm_.ToString());
			}
		}*/

		public static void CloseClient(int idx_){
			arrayClient[idx_] = null;
			lock(freeQueue){
				freeQueue.Enqueue(idx_);
			}

		}

		public static void ShutDown(){
			for(int loop = 0; loop < maxClientCount; loop++){
				if(arrayClient[loop] != null){
					arrayClient[loop].ShutDown();
				}
			}
		}

		private static int GetFreeId(){//-1 if no space left in array
			if(ClientCount < 1){
				return -1;
			}

			int freeId;
			lock(freeQueue){
				freeId = freeQueue.Dequeue();
			}
			return freeId;
		}
	}
}
