using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	private float waitingtime = 2.0f;//이것은 
	private float wait;
	private Vector2 baseposition;
	private float chasingwill = 3.0f;
	private float walkrange = 5.0f;
	private Vector2 randomValue = Random.insideUnitCircle;
	private Vector2 targetposition;
	void Start () {
		baseposition = this.transform.position;
		wait = waitingtime;
		transform.Find ("Enemy Sight").position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Sight.PlayerFind) {//이곳은 발견하기 전의 코드입니다.
			if (wait > 0.0f) {
				wait -= Time.deltaTime*5;
			} else {
				wait -= Time.deltaTime*5;
				transform.Translate (randomValue.x * Time.deltaTime*4, randomValue.y * Time.deltaTime*4 , 0); // 무작위의 방향으로 서성이게 만드는 스크립트입니다.
				if (wait < -3.0f) {
					wait = Random.Range (waitingtime, waitingtime * 3); //일정 시간이 지나면 정지하게 됩니다. 
					randomValue = Random.insideUnitCircle;
				}
			}
		} else {//이곳은 발견 했을때의 코드입니다.
			targetposition = GameObject.Find ("Player").transform.position;//플레이어의 위치를 발견한 다음 그 위치값을 반환합니다.
			chasingwill -= Time.deltaTime;//쫒는 속도를 받습니다.
			transform.position = Vector3.MoveTowards (transform.position, targetposition, 5 * Time.deltaTime);//그들을 이동하는 방향으로 쫒습니다
			if (chasingwill < 0f) {// 시야에서 벗어난지 어느정도 시간이 지나면 추격을 멈춥니다
				chasingwill = 3.0f;
				Sight.PlayerFind = false;
			}
		}
	}
}
