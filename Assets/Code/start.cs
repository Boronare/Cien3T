
	using UnityEngine;
	using System.Collections;

	public class First : MonoBehaviour {

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

			if(Input.GetKey(KeyCode.Return)) {
				Application.LoadLevel ("joystick");
			}
			/* 엔터키를 누르면 main 신을 불러오라는 의미 */
		}
	}
