using UnityEngine;
using System.Collections;

public class ButtonNextLvl : MonoBehaviour {
	public void Next_lvl(int index){
		Application.LoadLevel (index);
	}

	public void Close_lvl(){
		Application.Quit();
	}
}
