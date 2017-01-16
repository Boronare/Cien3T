using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Use this for initialization
	void Start () {
		GameObject character = (GameObject)Resources.LoadAll ("character" + Global.selectedChar, typeof(GameObject))[0];
		GameObject inst = Instantiate (character);
		inst.transform.SetParent (transform);
		inst.name = "character";
	}
	
	// Update is called once per frame

}
