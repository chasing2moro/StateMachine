using UnityEngine;
using System.Collections;


public class StateHint : HintBase {	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHandleStateHint(StateMachinePeople.StateType vStateType){
		switch (vStateType) {

		case StateMachinePeople.StateType.GetMedicine:
			SetLabel("GetMedicine State");
			break;
		case StateMachinePeople.StateType.GotHurt:
			SetLabel("GotHurt State");
			break;
		case StateMachinePeople.StateType.Idle:
			SetLabel("Idle State");
			break;
		default:
			break;
		}
	}
}
