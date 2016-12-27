using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotationController : EventTrigger 
{

	private Transform Character;
	private Image Stick;
	private Vector3 orignPos = Vector3.zero;


	void Awake()
	{
		Stick = transform.FindChild("Stick").GetComponent<Image> ();
		orignPos = gameObject.GetComponent<Image>().rectTransform.position;       
		//이때 하면 스틱의 좌표가 0인 상태일 수 있음으로, Start에서 초기좌표를 저장해둔다.
		//Start는 Awake()가 불려서 콤포넌트나 컨트롤들이 초기화 된후에 불린다.
	}


	void Start()
	{
		orignPos = Stick.transform.position;
	}
	void Update(){
		if(Character == null) Character = GameObject.Find ("character").transform;
	}
		
	public override void OnDrag(PointerEventData eData)
	{
		//Touch는 모바일장치(핸드폰/패드등)에서만 동작하니 주의, pc에서는 오동작할수 있음.
		//Touch touch = Input.GetTouch(0);
		float posX = eData.position.x;
		float posY = eData.position.y;        

		//터치한 곳과, 조이스틱 처음 위치를 기준으로, 이동한 방향을 구해둔다. 곧 캐릭터 이동에 사용한다.
		Vector3 dir = (orignPos - new Vector3(posX, posY, orignPos.z)).normalized*7;

		//터치한 부분이 조이스틱의 원래 위치기준으로 얼마나 움직였나를 체크한다.
		//차후에, 조이스틱이 영역을 벗어나면, 못 벗어나게 하는 처리등에 사용할 수 있다.
		float touchAreaRadius = Vector3.Distance(orignPos, new Vector3(posX, posY, orignPos.z));


		if (Stick != null)
		{
			//터치한 위치로, 조이스틱이 움직이도록 한다.
			Stick.rectTransform.position = orignPos - (dir * 10);
		}  

		if (Character != null) {
			float angle = Vector2.Angle(new Vector2 (0, -1), dir);

			Character.rotation = Quaternion.identity;

			if (dir.x < 0) {
				Character.Rotate (0,0,-angle);
			} else {
				Character.Rotate (0,0,angle);
			}
		}
	}

	public override void OnEndDrag(PointerEventData eData)
	{       
		//드래그가 끝나면, 터치가 끝난 것임으로, 조이스틱을 원위치로 이동시킨다.
		if (Stick != null)
		{
			Stick.rectTransform.position = orignPos;
		}   


	}
}
