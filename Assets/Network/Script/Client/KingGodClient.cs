using UnityEngine;
using System.Collections;

//개쩌는 클라이언트가 시작하는 부분, 유니티 메인 쓰레드에서 통신을 담당한다
namespace ClientSide
{
    public class KingGodClient : MonoBehaviour {

        public static KingGodClient Instance;

        private NetworkTranslator networkTranslator;
        private int freeId = -1;
	    public static KingGodClient instance;

	    void Awake(){
            if (Instance == null)           //Static 변수를 지정하고 이것이 없을경우 - PlayManage 스크립트를 저장하고 이것이 전 범위적인 싱글톤 오브젝트가 된다.
            {
                DontDestroyOnLoad(this.gameObject);
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);   //싱글톤 오브젝트가 있을경우 다른 오브젝트를 제거.
            }
            networkTranslator = GetComponent<NetworkTranslator>();

	    }

	    void Start () {
		    networkTranslator.SetMsgHandler(gameObject.AddComponent<DemoMsgHandler>());

		    Network_Client.Begin ();
	    }		

	    void OnApplicationQuit(){
		    Network_Client.ShutDown();
	    }

        public void Matching()
        {
            Network_Client.Send(freeId.ToString() + "/" + "Matching");
        }

        public void setFreeId(int freeId)
        {
            this.freeId = freeId;
        }
    }

}
