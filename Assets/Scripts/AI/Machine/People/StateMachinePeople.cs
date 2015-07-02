using UnityEngine;
using System.Collections;

public class StateMachinePeople : StateMachine<People, StateMachinePeople.StateType>
{
	public enum StateType
	{
		 GetMedicine,
		 GotHurt,
		 Idle,
	} 

	public StateMachinePeople(People vOwner) : base(vOwner){
		AddState(StateType.GetMedicine, new StatePeopleGetMedicine());
		AddState(StateType.GotHurt, new StatePeopleGotHurt());
		AddState(StateType.Idle, new StatePeopleIdle());
	}
}

