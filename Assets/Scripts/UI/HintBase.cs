using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UILabel))]
public class HintBase : MonoBehaviour
{
	public UILabel _Label;
	// Use this for initialization
	void Awake ()
	{
		_Label = GetComponent<UILabel>();
	}

	protected void SetLabel(string vStr){
		_Label.text = vStr;
	}

}

