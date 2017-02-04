using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	// Update is called once per frame
	IList<string> collidingList = new List<string>();//현재 접촉상황임을 확인 가ㅇ한


	// Use this for initialization
	void Start () {
		GameObject character = (GameObject)Resources.Load ("character" + Global.selectedChar, typeof(GameObject));
		GameObject inst = Instantiate (character);
		Global.playerChar = inst.GetComponent<Character> ();
		inst.transform.SetParent (transform);
		inst.name = "character";

	}

	void OnCollisionEnter2D(Collision2D coll){
		collidingList.Add (coll.collider.gameObject.tag);//콜리더값을 찾습니다.
	}

	void OnCollisionExit2D(Collision2D coll){
		collidingList.Remove (coll.collider.gameObject.tag);// 콜리더값을 다쓴 다음에 없앱니다 
	}
}
