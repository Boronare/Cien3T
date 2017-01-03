using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class healthbar : MonoBehaviour {
	public int hp = 100;
	public int speed=5;
	public Text hptext;

		void Start () {
		Global.recordedHp=hp;//글로벌 변수에게 HP전달
		Global.firsthp=hp; //글로벌 변수에 처음 hp를 
		Global.speedAmount = speed;//글로벌 변수에 처음 hp를
	}

	float DamageUpdateTime=0.0f;//데미지 받는 시간을 저장할 플로트
	void Update () {
		DamageUpdateTime += Time.deltaTime;//현재시간을 플로트에 저장 
		if (DamageUpdateTime > 0.5f) {
			TakeDamage ();//데미지를 받는 함수를 호
			DamageUpdateTime -= 0.5f;
		}//0.5초마다 시간을 보내줘서 제시간에 데미지 함수를 호출
	}

	void TakeDamage(){
		if (Global.damage!=0) {// 데미지를 받는 태그를 확인한다.
				//print ("health : " + hp);//데미지 확인용
				hp -= Global.damage;//데미지를 호출하고HP변화를작성한다.
				Global.recordedHp=hp;//글로벌 함수에 체력표를 올린다. 
				if (hp <= 0) {
				Global.gameover = true;//게임오버 상수를 반환한다.
				}
			Global.damage = 0;
		}
	}


		
}
