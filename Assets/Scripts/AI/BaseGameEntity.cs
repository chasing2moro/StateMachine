using UnityEngine;
using System.Collections;

public class BaseGameEntity : MonoBehaviour
{
	
	private int m_ID;//每个对象具有一个唯一的识别数字
	
	private static ArrayList m_idArray = new ArrayList();

	protected void SetID (int val)
	{
		
		//这个函数用来确认ID是否正确设置
		if (m_idArray.Contains(val)) {
			Debug.LogError ("id aleady existed");
			return;
		}
		
		m_idArray.Add(val);
		m_ID = val;
	}
	
	public int getID(){
		return m_ID;
	}
}