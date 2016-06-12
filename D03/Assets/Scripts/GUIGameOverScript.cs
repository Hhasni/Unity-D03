using UnityEngine;
using System.Collections;

public class GUIGameOverScript : MonoBehaviour {
	
	public gameManager		gM_Obj;
	private CanvasGroup		my_group;
	// Use this for initialization
	void Start () {
		my_group = GetComponent<CanvasGroup> ();
	}
	
	public void retry(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void giveup(){
		Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (gM_Obj.playerHp <= 0) {
			my_group.interactable = true;
			my_group.blocksRaycasts = true;
			my_group.alpha = 1;
			PauseScript.instance.blockWeapon();
		}
	}
}
