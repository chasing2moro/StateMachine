using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateDesignateNextState
{
	List<int> _designateToStateList = new List<int>();

	int tempInt;
	public void AddDesignateNextState(params int[] vToState){
		for (int i = 0; i < vToState.Length; i++) {
			tempInt = vToState[i];
			if(!_designateToStateList.Contains(tempInt))
				_designateToStateList.Add(tempInt);
		}

	}

	public bool ContainsNextState(int vToState){
		return _designateToStateList.Contains(vToState);
	}
}

