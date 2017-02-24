using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NetworkTranslator : MonoBehaviour {
	private MsgHandler msgHandler;

	void Awake(){
		
	}

	public void SetMsgHandler(MsgHandler msgHandler_){
		msgHandler = msgHandler_;
	}

	void Start(){
		StartCoroutine(DoParse());
	}

	private IEnumerator DoParse(){
		int msgCount = 0;
		int msgCountAcc = 0;
		float timeAcc = 0;
		while(true){
			msgCount = ReceiveQueue.GetCount();
			if(msgCount > 0){
				for(int loop = 0; loop < msgCount; loop++){
					msgHandler.HandleMsg(ReceiveQueue.SyncDequeMsg());
				}
			}

			timeAcc += Time.deltaTime;
			msgCountAcc += msgCount;
			if(timeAcc > 1){
				timeAcc = 0;
				msgCountAcc = 0;
			}

			yield return null;
		}
	}
}
