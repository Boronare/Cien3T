using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Return_Start: MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public	void OnClick(){
		SceneManager.LoadScene ("Scene/0_start",LoadSceneMode.Single);//초기 화면으로 이동합니다. 

	}
}
