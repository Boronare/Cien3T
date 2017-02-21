using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	List<Character> targlist=new List<Character>();
	public int dmg;
	void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("TriggerEnter");
		Character target = c.gameObject.GetComponent<Character>();
		foreach (Character cmp in targlist)
			if (cmp == target)
				return;
		target.takeDamage(dmg);
		c.GetComponent<Rigidbody2D>().MovePosition(c.transform.position+transform.rotation*new Vector2(0,5));
		//c.gameObject.transform.position+=transform.rotation*new Vector2(0,5);
		targlist.Add (target);
		Debug.Log ("Damaged!"+target.hp);
	}
	void OnTriggerStay2D(Collider2D c){
		Debug.Log ("TriggerStay");
	}
	void OnTriggerExit2D(Collider2D c){
		Debug.Log ("TriggerExit");
	}
	void OnEnable(){
		targlist.Clear ();
	}
	// Update is called once per frame
	void Update () {
	}
}
