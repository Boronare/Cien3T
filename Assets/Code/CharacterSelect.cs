using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {
	// Use this for initialization
	public GameObject Choosed;
	void Start () {
	
	}
	
	// Update is called once per frame

	public void characterSelect(int character) {
		transform.Find("SelectIndicator").position = transform.Find ("Character" + character).position;// 선택한 구간을 블러인 창을 두서 선택되었음을 표시한다 
		Global.selectedChar = character;//캐릭터의 변수는 charater0, charater1.
	}
	public void NextScene(){
		SceneManager.LoadScene ("Scene/main_scene_sw",LoadSceneMode.Single);//씬을 옮긴다.
	}
}
