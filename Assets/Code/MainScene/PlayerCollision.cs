using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

	class Damage{
		public string name = "";
		public int dmg;
	}


	IList<Damage> damageList = new List<Damage>(); //다양한 데미지들의 정보가 저장될 장소
	IList<string> collidingList = new List<string>();//현재 접촉상황임을 확인 가ㅇ한

	void Start () {
		Damage d = new Damage (){ name = "enemy", dmg = 3 };//태그 enemy에게 받는 데미지에 대한 정보를 저장하는것  
		damageList.Add (d);//데미지 리스트에 d를  
		Damage c = new Damage (){ name = "e", dmg = 20 };
		damageList.Add (c);// 데미지 리스트에 e를 저장한다. 

	}

	float DamageUpdateTime=0.0f;//데미지 받는 시간을 저장할 플로트
	void Update () {
		DamageUpdateTime += Time.deltaTime;//현재시간을 플로트에 저장 
		if (DamageUpdateTime > 0.5f) {
			TakeAllDamage ();//데미지를 받는 함수를 호
			DamageUpdateTime -= 0.5f;
		}//0.5초마다 시간을 보내줘서 제시간에 데미지 함수를 호출
	}
	void TakeAllDamage(){
		foreach (string tag in collidingList) {
			TakeDamage (tag);
		}
	}

	void TakeDamage(string tag){
		foreach (Damage dmg in damageList) {
			if (tag == dmg.name) {// 데미지를 받는 태그를 확인한다.
			Global.damage= dmg.dmg;//데미지 확인

			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		collidingList.Add (coll.collider.gameObject.tag);//콜리더값을 찾습니다.
	}

	void OnCollisionExit2D(Collision2D coll){
		collidingList.Remove (coll.collider.gameObject.tag);// 콜리더값을 다쓴 다음에 없앱니다 
	}

}
