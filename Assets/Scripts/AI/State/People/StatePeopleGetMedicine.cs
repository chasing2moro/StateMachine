using UnityEngine;
using System.Collections;

public class StatePeopleGetMedicine : StatePeopleBase
{
	public StatePeopleGetMedicine(){

	}

	public override void Enter(object vObj = null){
		base.Enter(vObj);
		Debug.Log("StatePeopleGetMedicine Enter");
		GetTarget().IncreaseHp();
	}
	
	
	public override void Execute(object vObj = null){
		
	}
	
	public override void Exit(object vObj = null){
		Debug.Log("StatePeopleGetMedicine Exit");
	}

}
