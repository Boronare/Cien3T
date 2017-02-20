using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	// Update is called once per frame


	// Use this for initialization
	void Start () {
		GameObject character = (GameObject)Resources.Load ("character" + Global.sel[0], typeof(GameObject));
		GameObject inst = Instantiate (character);
		Global.playerChar = inst.GetComponent<Character> ();
		inst.transform.SetParent (transform);
		inst.name = "character";

	}
}
