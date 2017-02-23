using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class PositionControllerAddSound : EventTrigger
{
	private Transform character;//player을 의미한다
	private Image stick;
	private Vector3 orignPos = Vector3.zero;

	void Awake()
	{
		character= GameObject.Find ("Player").transform;
		stick = transform.FindChild("Stick").GetComponent<Image> ();
		orignPos = gameObject.GetComponent<Image>().rectTransform.position;       
		//이때 하면 스틱의 좌표가 0인 상태일 수 있음으로, Start에서 초기좌표를 저장해둔다.
		//Start는 Awake()가 불려서 콤포넌트나 컨트롤들이 초기화 된후에 불린다.
	}


	void Start(){			
		orignPos = stick.transform.position;
	}

	Vector3 dir;
	bool isDragging = false;
	void Update(){
		if (isDragging == false)
			dir.Set (0, 0, 0);
		{//키보드입력 혼용 추가.
			Vector3 tdir=new Vector3();
			if (Input.GetKey (KeyCode.W))
				tdir.y = -1;
			else if (Input.GetKey (KeyCode.S))
				tdir.y = 1;
			if (Input.GetKey (KeyCode.A))
				tdir.x = 1;
			else if (Input.GetKey (KeyCode.D))
				tdir.x = -1;
			if (tdir.magnitude != 0)
				dir = tdir.normalized*3;
		}
		//Global.playerChar.GetComponent<Rigidbody2D>().velocity= -dir * Global.playerChar.speed;//캐릭터의 속도를 받고 이동한다.
		//Global.playerChar.GetComponent<Rigidbody2D>().MovePosition(dir*Global.playerChar.speed);
		Global.playerChar.transform.Translate (-dir * Global.playerChar.speed*Time.deltaTime,Space.World);
		character.position+=Global.playerChar.transform.localPosition;
		Global.playerChar.transform.localPosition = new Vector3 ();
		//camera.position=character.position;
	}

	public override void OnDrag(PointerEventData eData)
	{
		//Touch는 모바일장치(핸드폰/패드등)에서만 동작하니 주의, pc에서는 오동작할수 있음.
		//Touch touch = Input.GetTouch(0);
		float posX = eData.position.x;
		float posY = eData.position.y;        

		//터치한 곳과, 조이스틱 처음 위치를 기준으로, 이동한 방향을 구해둔다. 곧 캐릭터 이동에 사용한다.
		dir = (orignPos - new Vector3(posX, posY, orignPos.z)).normalized*3;
	
		//터치한 부분이 조이스틱의 원래 위치기준으로 얼마나 움직였나를 체크한다.
		//차후에, 조이스틱이 영역을 벗어나면, 못 벗어나게 하는 처리등에 사용할 수 있다.
		float touchAreaRadius = Vector3.Distance(orignPos, new Vector3(posX, posY, orignPos.z));


		if (stick != null)
		{
			//터치한 위치로, 조이스틱이 움직이도록 한다.
			stick.rectTransform.position = orignPos - (dir * 10);
		}  

		if (character != null) {
			isDragging = true;//드래그 할때 와 아닌때를 구분 한다.
		}
	}

	public override void OnEndDrag(PointerEventData eData)
	{       
		//드래그가 끝나면, 터치가 끝난 것임으로, 조이스틱을 원위치로 이동시킨다.
		if (stick != null)
		{
			stick.rectTransform.position = orignPos;
		}   

		isDragging = false;
	}

} 
