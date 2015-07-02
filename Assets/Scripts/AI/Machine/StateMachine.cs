using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine <TARGET, STATETYPE>
{
	public class StateType{
		public static int NULL = -1;
	}
	TARGET _owner;
	State<TARGET, STATETYPE> _currentState;
	State<TARGET, STATETYPE> _previousState;

	public StateMachine(TARGET vOwner){
		_owner = vOwner;
	}

	public void SetCurrentSate(STATETYPE vStateType){
		_currentState = GetState(vStateType);
		_currentState.SetTarget(_owner);
		_currentState.Enter();
	}

	public void Update(){
		if(_currentState != null)
			_currentState.Execute();
	}

	public bool ChagneState(STATETYPE vNewStateType, object vObj = null){
//		if(!_currentState.ContainsNextState(vNewStateType)){
//			Debug.Log("state " + _currentState.GetStateType() + " has no path to " + vNewStateType);
//			return false;
//		}

		_currentState.Exit(vObj);
		_previousState = _currentState;

		_currentState = GetState(vNewStateType);
		_currentState.SetTarget(_owner);
		_currentState.Enter(vObj);
		return true;
	}


	Dictionary<STATETYPE, State<TARGET, STATETYPE>> _id2State = new Dictionary<STATETYPE, State<TARGET, STATETYPE>>();
	protected void AddState(STATETYPE vStateType, State<TARGET, STATETYPE> vState){
		_id2State[vStateType] = vState;
		vState.SetStateType(vStateType);
	}


	State<TARGET, STATETYPE> GetState(STATETYPE vStateType){
		State<TARGET, STATETYPE> temp = null;
		_id2State.TryGetValue(vStateType, out temp);
		return temp;
	}

}

