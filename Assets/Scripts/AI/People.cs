using UnityEngine;
using System.Collections;

public class People : BaseGameEntity
{
	public int m_hp = 100;
	StateMachinePeople _stateMachine;
	public void SetHp(int vHp){
		m_hp = vHp;
		BroadcastMessage("OnHandleHPHint", m_hp, SendMessageOptions.DontRequireReceiver);
	}
	public int IncreaseHp(){
		SetHp(m_hp + 5);
		return m_hp;
	}
	public int DecreaseHp(){
		SetHp(m_hp - 5);
		return m_hp;
	}
	public int GetHp(){
		return m_hp;
	}

	void Start(){
		SetID((int) this.GetHashCode());

		_stateMachine = new StateMachinePeople(this);
		_stateMachine.SetCurrentSate(StateMachinePeople.StateType.Idle);

		SetHp(100);

	}

	void Update(){
		_stateMachine.Update();
	}

	[ContextMenu("got hurt")]
	void GotHurt(){
		_stateMachine.ChagneState(StateMachinePeople.StateType.GotHurt);
	}

	[ContextMenu("get medicine")]
	void GetMedicine(){
		_stateMachine.ChagneState(StateMachinePeople.StateType.GetMedicine);
	}
}

