using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {
	public GameObject gameoverscreen;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		checkGameOver (Global.playerChar.hp);
		if (Input.GetKeyDown (KeyCode.Space))
			sendDebugMsg ();
	}
	void checkGameOver(int hp){
		this.gameoverscreen.SetActive (hp<=0?true:false);
	}
	void sendDebugMsg(){
	}
}
