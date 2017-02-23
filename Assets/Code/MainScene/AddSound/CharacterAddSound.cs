using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class CharacterAddsound : MonoBehaviour {
	public int id;
	public int maxhp;
    public int hp;
    public int speed;


	public void takeDamage(int damage){
		hp -= damage;
		if (hp <= 0) {
			die ();//게임오버 상수를 반환한다.
		}
	}
	public void attack(){
		GetComponent<Animator> ().Play ("Attack");
	}
	void die(){
		if (this == Global.playerChar)
			MainScene.gameover();
		GetComponent<Animator> ().Play ("Attack");
		gameObject.SetActive (false);
	}
}
