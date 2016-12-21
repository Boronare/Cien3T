using UnityEngine;
using System.Collections;

public class Sight : MonoBehaviour {
	public static bool PlayerFind = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D c){
		PlayerFind = true;
	}
}
