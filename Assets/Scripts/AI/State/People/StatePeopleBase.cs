using UnityEngine;
using System.Collections;

public class StatePeopleBase : State<People, StateMachinePeople.StateType>
{

	public override void Enter(object vObj = null){
		base.Enter(vObj);
		GetTarget().gameObject.BroadcastMessage("OnHandleStateHint", this.GetStateType(), SendMessageOptions.DontRequireReceiver);
	}
}

