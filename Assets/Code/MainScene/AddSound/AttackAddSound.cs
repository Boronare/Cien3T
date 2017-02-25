using System.Collections.Generic;
using UnityEngine;

public class AttackAddSound : MonoBehaviour {
    private AudioSource AttackAudio;
    public AudioClip AttackSound;
    List<Character> targlist=new List<Character>();
	public int dmg;

    void Awake()
    {
        this.AttackAudio = this.gameObject.AddComponent<AudioSource>();
        this.AttackAudio.clip = this.AttackSound;
        this.AttackAudio.loop = false;

    }
    void OnTriggerEnter2D(Collider2D c){
		Debug.Log ("TriggerEnter");
		Character target = c.gameObject.GetComponent<Character>();
		foreach (Character cmp in targlist)
			if (cmp == target)
				return;
		target.takeDamage(dmg);
		c.gameObject.transform.position+=transform.rotation*new Vector3(0,5,0);
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
        this.AttackAudio.Play();
        targlist.Clear ();
	}
	// Update is called once per frame
	void Update () {
    
    }
}
