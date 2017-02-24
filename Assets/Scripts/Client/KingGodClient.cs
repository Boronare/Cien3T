using UnityEngine;
using System.Collections;

//개쩌는 클라이언트가 시작하는 부분, 유니티 메인 쓰레드에서 통신을 담당한다
public class KingGodClient : MonoBehaviour {
	private NetworkTranslator networkTranslator;

	public static KingGodClient instance;

	void Awake(){
		DontDestroyOnLoad(gameObject);
		instance = this;
		networkTranslator = GetComponent<NetworkTranslator>();

	}

	void Start () {
		networkTranslator.SetMsgHandler(gameObject.AddComponent<DemoMsgHandler>());

		Network_Client.Begin ();
	}		
	/*
	public void OnExitPlayScene(){
		Destroy(gameObject.GetComponent<MsgHandler>());
		networkTranslator.SetMsgHandler(gameObject.AddComponent<Client_StartMsgHandler>());
	}

	public void OnEnterPlayScene(){
		Destroy(gameObject.GetComponent<MsgHandler>());
		networkTranslator.SetMsgHandler(gameObject.AddComponent<Client_MsgHandler>());
	}

	public void BeginNetworking(){//네트워킹이 최초 시동되는 부분
		Network_Client.Begin();

		//StartCoroutine(NetworkSetup());
	}

	private IEnumerator NetworkSetup(){
		ConsoleMsgQueue.EnqueMsg("Waiting for connection...");
		while(Network_Client.IsConnected == false){
			yield return null;
		}
			
		MsgSegment h = new MsgSegment(MsgAttr.setup);
		MsgSegment b = new MsgSegment(MsgAttr.Setup.reqId);
		NetworkMessage msgRequestId = new NetworkMessage(h, b);

		NetworkMessage.SenderId = Network_Client.NetworkId.ToString();
		while(Network_Client.NetworkId == -1){
			ConsoleMsgQueue.EnqueMsg("Request Id to Server...");
			Network_Client.Send(msgRequestId);
			yield return new WaitForSeconds(1);
		}

		Network_Client.Send(new NetworkMessage());//id가 갱신되었음을 알리는 빈 메시지 전송

		ConsoleMsgQueue.EnqueMsg("Received Id: " + Network_Client.NetworkId);

		StartSceneManager.instance.OnNetworkSetupDone();
	}*/

	void OnApplicationQuit(){
		Network_Client.ShutDown();
	}
}
