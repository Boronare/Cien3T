using UnityEngine;
using System.Collections;

public class Game_Over : MonoBehaviour {
	public GameObject gameoverscreen;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.gameover == true) {
			Debug.Log ("asdf");
			this.gameoverscreen.SetActive (true);
		}
		if (Global.gameover == false){
			this.gameoverscreen.SetActive (false);
		}
	}
}
