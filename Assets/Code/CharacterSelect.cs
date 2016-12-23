using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	public void characterSelect(int character) {
		transform.Find("SelectIndicator").position = transform.Find ("Character" + character).position;	
		Global.selectedChar = character;
	}
	public void NextScene(){
		SceneManager.LoadScene ("Scene/main_scene_sw",LoadSceneMode.Single);
	}
}
