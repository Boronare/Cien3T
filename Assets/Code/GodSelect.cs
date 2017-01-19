using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GodSelect : MonoBehaviour {
	// Use this for initialization
	public GameObject Choosed;
	void Start () {
	
	}
	
	// Update is called once per frame

	public void godSelect(int god){
		transform.Find ("SelectIndicator1").position = transform.Find ("God" + god).position;// 선택한 구간을 블러인 창을 두서 선택되었음을 표시한다 
		Global.selectedGod = god;//캐릭터의 변수는 god0, god1.
	}
	public void NextScene(){
		SceneManager.LoadScene ("Scene/main_scene_sw",LoadSceneMode.Single);//씬을 옮긴다.
	}
}
