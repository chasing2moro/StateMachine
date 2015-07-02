using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateListener 
{
	public delegate void StateListenerEvent(object vObj);

	Dictionary<int, StateListenerEvent> _id2ToStateListenerEvent= new Dictionary<int, StateListenerEvent>();
	public void ListenToStateEvent(int vStateType, StateListenerEvent vSateListenerEvent){
		ListenStateEvent(_id2ToStateListenerEvent,
		                 vStateType, 
		                 vSateListenerEvent);
	}
	public void FireToStateEvent(int vStateType, object vObj){
		FireStateEvent(_id2ToStateListenerEvent,
		               vStateType,
		               vObj);
	}

	Dictionary<int, StateListenerEvent> _id2FromStateListenerEvent= new Dictionary<int, StateListenerEvent>();
	public void ListenFromStateEvent(int vStateType, StateListenerEvent vSateListenerEvent){
		ListenStateEvent(_id2FromStateListenerEvent,
		                 vStateType, 
		                 vSateListenerEvent);
	}
	public void FireFromStateEvent(int vStateType, object vObj){
		FireStateEvent(_id2FromStateListenerEvent,
		               vStateType,
		               vObj);
	}

	public void ListenStateEvent(Dictionary<int, StateListenerEvent> vDic,
	                             int vStateType, 
	                             StateListenerEvent vSateListenerEvent){
		if(vDic.ContainsKey(vStateType)){
			vDic[vStateType] += vSateListenerEvent;
		}else{
			vDic[vStateType] = vSateListenerEvent;
		}

	}
	
	public void FireStateEvent(Dictionary<int, StateListenerEvent> vDic,
	                           int vStateType,
	                           object vObj){
		if(vDic.ContainsKey(vStateType))
			vDic[vStateType](vObj);
	}
}

