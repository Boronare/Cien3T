using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectMenu : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	public void characterSelect(int character) {
		transform.Find("SelectIndicator").position = transform.Find ("Character" + character).position;// 선택한 구간을 블러인 창을 두서 선택되었음을 표시한다 
		Global.sel[0] = character;//캐릭터의 변수는 character0, character1.
	}
	public void godSelect(int god){
		transform.Find ("SelectIndicator1").position = transform.Find ("God" + god).position;// 선택한 구간을 블러인 창을 두서 선택되었음을 표시한다 
		Global.sel[1] = god;//캐릭터의 변수는 god0, god1.
	}
	public void NextScene(){
		SceneManager.LoadScene ("Scene/main_scene_sw",LoadSceneMode.Single);//씬을 옮긴다.
	}

}
