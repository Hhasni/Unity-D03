using UnityEngine;
using System.Collections;

public class ConfirmQuitScript : MonoBehaviour {
	
	public gameManager	gM_obj;
	public PauseScript	motherScript;
	private CanvasGroup	my_group;
	public bool			active;
	// Use this for initialization
	void Start () {
		my_group = GetComponent<CanvasGroup> ();
	}

	public void QuitYes(){
		active = false;
		Application.LoadLevel (0);
	}

	public void ContinueNo(){
		my_group.alpha = 0;
		my_group.blocksRaycasts = false;
		my_group.interactable = false;
		motherScript.my_bool = false;
		active = false;
		gM_obj.pause(false);
	}

	// Update is called once per frame
	void Update () {

	}
}
