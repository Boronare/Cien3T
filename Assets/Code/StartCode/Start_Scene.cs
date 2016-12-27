	using UnityEngine;
	using System.Collections;
using UnityEngine.SceneManagement;

public class Start_Scene: MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
		
		}

	 public	void OnClick(){
		SceneManager.LoadScene ("Scene/Choosing_Char",LoadSceneMode.Single);// 캐릭터 선택창으로 이동
		Global.gameover = false;//게임 오버창을 종료 하는 것을 글로벌 함수에 저장해둠
	}
}
