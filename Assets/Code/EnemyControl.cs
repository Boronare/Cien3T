using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	private float waitingtime = 2.0f;
	private float wait;
	private Vector2 baseposition;
	private float walkrange = 5.0f;
	private Vector2 randomValue = Random.insideUnitCircle;
	// Use this for initialization
	void Start () {
		baseposition = this.transform.position;
		wait = waitingtime;
	}
	
	// Update is called once per frame
	void Update () {
		if (wait > 0.0f) {
			wait -= Time.deltaTime;
		} else {
			wait -= Time.deltaTime;
			transform.Translate (randomValue.x * Time.deltaTime/2, randomValue.y * Time.deltaTime/2, 0);
			if (wait < -2.0f) {
				wait = Random.Range (waitingtime, waitingtime * 2);
				randomValue = Random.insideUnitCircle;
			}
		}
	}
}
