
using UnityEngine;
using System.Collections;
using System;

public class TurnplateActivityPanel : MonoBehaviour 
{
	public GameObject mRotateTarget;
	
	void Start ()
	{
		
	}
	
	void Init()
	{
		//m_fTurnStartTimes = Time.realtimeSinceStartup;		// 旋转起始秒数
	//	m_fFixTurnTimes   = 5f;								// 固定旋转秒数
		m_fUnitDegree  	  = 360.0f / 16f;					// 单位旋转度数
		m_fDsetDegree 	  = ((16 + 1 - m_iRewardIndex) % 16) * m_fUnitDegree;	// 目标旋转度数
		m_iRotateSpeedVal = 0;							// 起始旋转速度
		//m_fLateEndTimes   = 3f;								// 减速耗时
		m_bTurn 		  = true;
		m_SpeedDownState = false;
	}
	
	public void Show( bool bValue )
	{
		if( bValue )
		{
			
		}
		gameObject.SetActive ( bValue );
	}
	
	void OnClickCloseEvent( GameObject obj )
	{
		Show ( false );
	}
	
	void OnClickBeginTurn( GameObject obj )
	{
		Debug.Log("Init");
		Init ();
	}
	
	void Update()
	{
		if( m_bTurn )
		{
			//if( Time.realtimeSinceStartup - m_fTurnStartTimes >  m_fFixTurnTimes )
			///{
			//	UpdateTurnLate();
			//}
			if(m_SpeedDownState && m_iRotateSpeedVal < 100){
				if(Mathf.Abs(mRotateTarget.transform.eulerAngles.z - m_fDsetDegree) >  4){
					m_iRotateSpeedVal = Mathf.Lerp(m_iRotateSpeedVal, 0, 0.0001f * Time.deltaTime);
					float degree = ( Time.deltaTime * m_iRotateSpeedVal ) % 360;
					mRotateTarget.transform.Rotate (-degree * Vector3.forward );
				}else{
					Debug.Log("UpdateTurnLate m_iRotateSpeedVal = 0");
					Vector3 tempEulerAngles = mRotateTarget.transform.localEulerAngles;
					tempEulerAngles.z = (float)m_fDsetDegree;
					mRotateTarget.transform.localEulerAngles = tempEulerAngles;
					m_iRotateSpeedVal = 0;
					m_bTurn = false;
				}
			}else{
				UpdateTurnLate();
				float degree = ( Time.deltaTime * m_iRotateSpeedVal ) % 360;
				mRotateTarget.transform.Rotate (-degree * Vector3.forward );
			}

		}
	}

	void UpdateTurnLate()
	{
		if(!m_SpeedDownState){
			if(m_MaxRotateSpeedVal - m_iRotateSpeedVal > m_e){
				//Debug.Log("SpeedUp m_iRotateSpeedVal:" + m_iRotateSpeedVal);
				m_iRotateSpeedVal = Mathf.Lerp(m_iRotateSpeedVal, m_iRotateSpeedVal < 500 ? 520 :m_MaxRotateSpeedVal, m_SpeedUpFactor * Time.deltaTime);
			}else{
				//Debug.Log("UpdateTurnLate m_iRotateSpeedVal = Max");
				m_iRotateSpeedVal = m_MaxRotateSpeedVal;
				m_SpeedDownState = true;
			}
		}else{
			if(m_iRotateSpeedVal > m_e){
				Debug.Log("SpeedDown m_iRotateSpeedVal:" + m_iRotateSpeedVal);
				m_iRotateSpeedVal = Mathf.Lerp(m_iRotateSpeedVal, 0, m_SpeedDownFactor * Time.deltaTime);
			}

//			else{
//				Debug.Log("UpdateTurnLate m_iRotateSpeedVal = 0");
//				m_iRotateSpeedVal = 0;
//				m_bTurn = false;
//			}
		}
	}

	void RestStayInMaxSpeedState(){
		m_SpeedDownState = false;
	}
	// 私有数据 
	private float 	 m_iRotateSpeedVal;				// 起始旋转速度
	//private float    m_fTurnStartTimes; 			// 旋转起始秒数
	//private float    m_fFixTurnTimes; 	 			// 固定旋转秒数
	
	private float 	 m_fUnitDegree;					// 单位旋转度数
	private float    m_fDsetDegree;					// 目标旋转度数
	
	//private float    m_fLateEndTimes;				// 减速耗时
	public float      m_SpeedUpFactor = 0.01f;				// 速因子
	public float 	  m_SpeedDownFactor = 0.8f;// 减速因子
	
	private bool     m_bTurn;						// 是否开启旋转

	// 服务器传入数据
	public int      m_iRewardIndex = 8;			// 服务器奖励下标

	//bobo add
	public float 	m_MaxRotateSpeedVal = 800;
	public float	m_e = 0.5f;
	private bool     m_SpeedDownState = false;
	
}