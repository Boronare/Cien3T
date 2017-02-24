using UnityEngine;
using System.Collections;

//서버 사이드에서 통신에 관련된 일들을 전담한다.
//유니티 메인쓰레드에서 작동한다
namespace ServerSide{
	public class ServerSide_Main : MonoBehaviour {
		private NetworkTranslator networkTranslator;

		void Awake(){
			networkTranslator = GetComponent<NetworkTranslator>();
		}

		void Start () {
			networkTranslator.SetMsgHandler(gameObject.AddComponent<ServerMsgHandler>());

			ServerSide.Network_Server.Begin();
		}
        


		void OnApplicationQuit(){
			ServerSide.Network_Server.ShutDown();
		}
	}
}