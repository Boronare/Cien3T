using System.Collections;
using System.Collections.Generic;

public class ReceiveQueue {
	private static Queue<string> msgQue = new Queue<string>();

	public static int GetCount(){
		int msgCount;
		lock(msgQue){
			msgCount = msgQue.Count;
		}

		return msgCount;
	}

	public static void EnqueMsg(string msg){
		msgQue.Enqueue(msg);
	}

	public static void SyncEnqueMsg(string msg){
		lock(msgQue){
			msgQue.Enqueue(msg);
		}
	}

	public static string DequeMsg(){
		return msgQue.Dequeue();
	}

	public static string SyncDequeMsg(){
		string msg;
		lock(msgQue){
			msg = msgQue.Dequeue();
		}

		return msg;
	}
}
