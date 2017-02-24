using System;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;
using UnityEngine;


namespace ServerSide{
	public class TcpConnection {
		private Socket socket;

		private int clientId;
		public int ClientId{
			get{return clientId;}
		}

		private NetworkStream networkStream;
		private StreamReader streamReader;
		private StreamWriter streamWriter;

		private Thread thread_receive;
		private bool isConnected;
		public bool IsConnected{
			get{return isConnected;}
		}
			
		public TcpConnection (Socket socket_, int id_){
			socket = socket_;

			clientId = id_;

			networkStream = new NetworkStream(socket);
			streamReader = new StreamReader(networkStream, Encoding.UTF8);
			streamWriter = new StreamWriter(networkStream, Encoding.UTF8);

			thread_receive = new Thread(ReceivingOperation);

			isConnected = true;
			thread_receive.Start();
		}

		public void Send(string str){
			try{
				Debug.Log(clientId + ": Send: " + str);
				streamWriter.WriteLine(str);
				streamWriter.Flush();
			}catch(Exception e){
				Debug.Log(clientId + ": Send: " + e.Message);
				isConnected = false;
			}
		}


		private void ReceivingOperation(){
			//IdSync();

			/*
			MsgSegment h = new MsgSegment(MsgAttr.local, "");
			MsgSegment b = new MsgSegment(MsgAttr.Local.disconnect, clientId.ToString());
			NetworkMessage dyingMsg = new NetworkMessage(h, b);
			*/

			string recStr;
			try{
				while(isConnected){
					recStr = streamReader.ReadLine();

					if(recStr != null){
						Debug.Log(clientId + ": Received: " + recStr);
						ReceiveQueue.SyncEnqueMsg(recStr);
					}else{
						isConnected = false;
					}
				}
			}catch(Exception e){
				//ConsoleMsgQueue.EnqueMsg(clientId + ": ReceiveOperation: " + e.Message);
				//ReceiveQueue.SyncEnqueMsg(dyingMsg);
			}

			//ConsoleMsgQueue.EnqueMsg(clientId + ": Disconnected.");
			isConnected = false;
			ClientManager.CloseClient(clientId);

			streamReader.Close();
		}

		/*
		private void IdSync(){//client에게 네트워크에서의 id를 가르쳐주는 과정
			string recStr;

			try{
				while(isConnected){
					recStr = streamReader.ReadLine();

					if(recStr != null){
						ConsoleMsgQueue.EnqueMsg(clientId + ": Received: " + recStr, 0);
						NetworkMessage nm = new NetworkMessage(recStr);
						if(nm.Adress.Attribute.Equals("-1")){//발신자 id가 -1이면 클라이언트에게 네트워크 id 전송해줌
							MsgSegment h = new MsgSegment(MsgAttr.setup);
							MsgSegment b = new MsgSegment(MsgAttr.Setup.reqId, clientId.ToString());
							NetworkMessage idInfo = new NetworkMessage(h, b);
							Send(idInfo.ToString());
						}else{
							break;
						}
					}else{
						isConnected = false;
					}
				}
			}catch(Exception e){
				ConsoleMsgQueue.EnqueMsg(clientId + ": IdSync: " + e.Message);
			}

			ConsoleMsgQueue.EnqueMsg(clientId + ": IdSync Done.");
		}*/


		public void ShutDown(){
			streamWriter.Close();
			streamReader.Close();
			socket.Shutdown(SocketShutdown.Both);

			ClientManager.CloseClient(clientId);
		}
	}
}