using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class healthbar : MonoBehaviour {
	public int hp = 100;
	public Text hptext;

	class Damage{
		public string name = "";
		public int dmg;
	}


	IList<Damage> damageList = new List<Damage>(); //다양한 데미지들의 정보가 저장될 장소
	IList<string> collidingList = new List<string>();//현재 접촉상황임을 확인 가ㅇ한

	void Start () {
		Global.recordedHp=hp;
		Global.firsthp=hp;
		Damage d = new Damage (){ name = "enemy", dmg = 3 };//태그 enemy의 데미지에 대한 정보를 저장하는것  
		damageList.Add (d);
		Damage c = new Damage (){ name = "e", dmg = 20 };
		damageList.Add (c);

	}

	float DamageUpdateTime=0.0f;//데미지 받는 시간을 저장할 플로트
	void Update () {
		DamageUpdateTime += Time.deltaTime;//현재시간을 플로트에 저장 
		if (DamageUpdateTime > 0.5f) {
			TakeAllDamage ();
			DamageUpdateTime -= 0.5f;
		}//0.5초마다 시간을 보내줘서 제시간에 데미지 함수를 호출


	}

	void TakeDamage(string tag){
		foreach (Damage dmg in damageList) {
			if (tag == dmg.name) {// 데미지를 받는 태그를 확인한다.
				//print ("health : " + hp);//데미지 확인용
				hp -= dmg.dmg;//체력 감소
				Global.recordedHp=hp;
				if (hp <= 0) {
					Debug.Log ("af");
				Global.gameover = true;//게임오버 상수를 반환한다.
				}
			}
		}
	}
	void TakeAllDamage(){
		foreach (string tag in collidingList) {
			TakeDamage (tag);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		collidingList.Add (coll.gameObject.tag);
	}

	void OnTriggerExit2D(Collider2D coll){
		collidingList.Remove (coll.gameObject.tag);
	
	}
		
}
