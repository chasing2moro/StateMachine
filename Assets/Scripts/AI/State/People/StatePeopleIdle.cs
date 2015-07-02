using UnityEngine;
using System.Collections;

public class StatePeopleIdle : StatePeopleBase
{
	public StatePeopleIdle(){

	}
	
	public override void Enter(object vObj = null){
		base.Enter(vObj);
		Debug.Log("StatePeopleIdle Enter");
	}
	
	
	public override void Execute(object vObj = null){
		
	}
	
	public override void Exit(object vObj = null){
		Debug.Log("StatePeopleIdle Exit");
	}
}

