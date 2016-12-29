using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class HP_Change : MonoBehaviour {
	public Image imgHpbar;//HP의 크기를 나타낼 사진
	private int inithp;//처음의 HP를 받을 곳
	public int hp;// 계속해서 바뀌는 HP를 받을 곳
	

	// Use this for initialization
	void Start () {
	}	
	// Update is called once per frame
	void Update (){
		inithp = Global.firsthp;//초기Hp값을 글로벌로 부터 받아낸다.
		hp = Global.recordedHp;//hp 값을 글로벌값으로부터 받아낸다
		imgHpbar.fillAmount = (float)hp / (float)inithp;//증감수치를 통해서 크기를 바꾼다.			
	}


}
