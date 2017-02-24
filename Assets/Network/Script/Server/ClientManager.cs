using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using UnityEngine;

namespace ServerSide{
	public static class ClientManager {		
		private const int maxClientCount = 100;
        private static System.Random random = new System.Random();
		private static TcpConnection[] arrayClient;
		private static Queue<int> freeQueue;
		public static Int32 ClientCount{
			get{
				return freeQueue.Count;
			}
		}

		
        private static List<Match> matches = new List<Match>();
        private static int matchCount = 0;



		public static void Init(){
			freeQueue = new Queue<int>();
			for(int loop = 0; loop < maxClientCount; loop++) {
				freeQueue.Enqueue(loop);
			}

			arrayClient = new TcpConnection[maxClientCount];
		}

		public static bool AddClient(Socket welcomeSocket_) {
			int freeId = GetFreeId();
			if(freeId == -1) {
				welcomeSocket_.Disconnect(false);
				return false;
			}
			else {
				arrayClient[freeId] = new TcpConnection(welcomeSocket_, freeId);
				if(matches.Count == 0) {
					matches.Add(new Match(freeId));
				}
				else if(matches[matches.Count - 1].getPlayerCount() == matches[matches.Count - 1].getMax()-1) {
					matches[matches.Count - 1].addPlayer(freeId);
					
				}
				else {
					matches.Add(new Match(freeId));
				}

				return true;
			}
			
		}
        public static void Send(int freeId, string nm_) {
            if (arrayClient[freeId] != null)
                arrayClient[freeId].Send(nm_);
        }
		public static void Send(Match match, string nm_) {
			for(int index =0; index < match.getPlayerCount(); index++) {
				if(arrayClient[match.getFreeId(index)] != null)
					arrayClient[match.getFreeId(index)].Send(nm_);

			}
		}
		public static void BroadCast(string nm_) {
			if(arrayClient == null)return;
			
			for(int loop = 0; loop < maxClientCount; loop++) {
				if(arrayClient[loop] != null){
					if (arrayClient [loop].IsConnected) {						
						arrayClient [loop].Send (nm_);
					}
				}
			}
		}
		public static void BroadCastToMatch(int id, string nm_) {
			if(arrayClient == null) return;
			int index = findMatchIndex(id);
			if(index != -1)			
				for(int i = 0; i < matches[index].getPlayerCount(); i++)
					arrayClient[matches[index].getFreeId(i)].Send(nm_);
			
		}
		
		public static void CloseClient(int idx_)  {
			arrayClient[idx_] = null;
			lock(freeQueue){
				freeQueue.Enqueue(idx_);
			}

		}
		public static void ShutDown() {
			for(int loop = 0; loop < maxClientCount; loop++) {
				if(arrayClient[loop] != null){
					arrayClient[loop].ShutDown();
				}
			}
		}
		private static int GetFreeId() {//-1 if no space left in array
			if(ClientCount < 1) {
				return -1;
			}
			int freeId;
			lock(freeQueue) {
				freeId = freeQueue.Dequeue();
			}
			return freeId;
		}
        public static TcpConnection getClient(int idx) {
			return arrayClient[idx];
		}

        public static bool DeQueClient(int id) {
            for(int index = 0; index<matches.Count; index++) {
                if(matches[index].getPlayerCount() != matches[index].getMax()
					&& matches[index].removePlayer(id)) {
						Send(id, "DequeComplete");
						arrayClient[id].ShutDown();
						arrayClient[id] = null;
						return true;
                }
            }
            return false;
        }
        private static int findMatchIndex(int id) {
			for(int index = 0; index < matches.Count; index++) {
					if(matches[index].findPlayer(id) == id)
						return index;
			}
			return -1;
        }
        public static bool ready(int id) {
			int index = findMatchIndex(id);
			if(index == -1)
				return false;
			matches[index].setReady(id);
			if(matches[index].isAllReady()) {
				Send(matches[index], "Start");
			}
				
            return true;
        }		
    }
}
