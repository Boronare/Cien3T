using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
public class HP_Change : MonoBehaviour {
	public Image imgHpbar;
	private int inithp;
	public int hp;
	//public Image deathpanel;

	// Use this for initialization
	void Start () {
	}	
	// Update is called once per frame
	void Update (){
		inithp = Global.firsthp;
		hp = Global.recordedHp;
		imgHpbar.fillAmount = (float)hp / (float)inithp;//증감수치를 통해서 크기를 바꾼다.			
	}


}
