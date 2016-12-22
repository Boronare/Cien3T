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
		Debug.Log ("asdf");
		SceneManager.LoadScene ("Scene/main_scene_sw",LoadSceneMode.Single);
		}
}
