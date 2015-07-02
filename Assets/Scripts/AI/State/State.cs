using UnityEngine;
using System.Collections;

public class State <TARGET, STATETYPE>
{
	TARGET _Target;
	public void SetTarget(TARGET vTarget){
		_Target = vTarget;
	}
	public TARGET GetTarget(){
		if(_Target == null)
			Debug.LogError("_Target == null");
		return _Target;
	}

	STATETYPE _stateType;
	public void SetStateType(STATETYPE vStateType){
		_stateType = vStateType;
	}
	protected STATETYPE GetStateType(){
		return _stateType;
	}
	

	public virtual void Enter(object vObj = null){

	}
	

	public virtual void Execute(object vObj = null){

	}

	public virtual void Exit(object vObj = null){

	}
	
}

