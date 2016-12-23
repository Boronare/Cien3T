using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	private float waitingtime = 2.0f;
	private float wait;
	private Vector2 baseposition;
	private float chasingwill = 3.0f;
	private float walkrange = 5.0f;
	private Vector2 randomValue = Random.insideUnitCircle;
	private Vector2 targetposition;
	// Use this for initialization
	void Start () {
		baseposition = this.transform.position;
		wait = waitingtime;
		transform.Find ("Enemy Sight").position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Sight.PlayerFind) {
			if (wait > 0.0f) {
				wait -= Time.deltaTime*2;
			} else {
				wait -= Time.deltaTime*2;
				transform.Translate (randomValue.x * Time.deltaTime / 2, randomValue.y * Time.deltaTime / 2, 0);
				if (wait < -2.0f) {
					wait = Random.Range (waitingtime, waitingtime * 2);
					randomValue = Random.insideUnitCircle;
				}
			}
		} else {
			targetposition = GameObject.Find ("Player").transform.position;
			chasingwill -= Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, targetposition, 5 * Time.deltaTime);
			if (chasingwill < 0f) {
				chasingwill = 3.0f;
				Sight.PlayerFind = false;
			}
		}
	}
}
