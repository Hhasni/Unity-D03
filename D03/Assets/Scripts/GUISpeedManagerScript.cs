using UnityEngine;
using System.Collections;

public class GUISpeedManagerScript : MonoBehaviour {

	public bool		pause;
	public gameManager	gM_Obj;
	// Use this for initialization
	void Start () {
		pause = false;
	
	}

	public void Pause(){
		if (pause) {
			pause = false;
			gM_Obj.pause (false);
		}
		else{
			pause = true;
			gM_Obj.pause (true);
		}
	}
		
	public void PlaySpeedX1(){
		pause = false;
		gM_Obj.changeSpeed (1f);
	}
		
	public void PlaySpeedX2(){
		pause = false;
		gM_Obj.changeSpeed (2f);

	}
	
	public void PlaySpeedX4(){
		pause = false;
		gM_Obj.changeSpeed (4f);

	}

	// Update is called once per frame
	void Update () {

	
	}
}
