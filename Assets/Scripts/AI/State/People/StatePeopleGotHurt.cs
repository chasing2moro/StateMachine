using UnityEngine;
using System.Collections;

public class StatePeopleGotHurt : StatePeopleBase
{
	public StatePeopleGotHurt(){

	}

	public override void Enter(object vObj = null){
		base.Enter(vObj);
		Debug.Log("StatePeopleGotHurt Enter");
		GetTarget().DecreaseHp();

	}
	
	
	public override void Execute(object vObj = null){
		
	}
	
	public override void Exit(object vObj = null){
		Debug.Log("StatePeopleGotHurt Exit");
	}
}
