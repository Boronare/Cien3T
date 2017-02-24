using UnityEngine;
using System.Collections;

public abstract class MsgHandler : MonoBehaviour {
	public abstract void HandleMsg(string networkMessage);
}
