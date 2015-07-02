using UnityEngine;
using System.Collections;


public class HPHint : HintBase {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnHandleHPHint(int vHP){
		SetLabel("HP:" + vHP);
	}
}
