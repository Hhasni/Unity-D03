using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	public static PauseScript instance { get; private set;}

	public bool 		my_bool;
	public gameManager	gM_obj;
	public GuiWeapon[]	wp;
	private CanvasGroup	my_group;
	public CanvasGroup	confirmation;
	public ConfirmQuitScript child;

	// Use this for initialization
	void Awake(){
		instance = this;
	}
	void Start () {
		my_group = GetComponent<CanvasGroup> ();
		my_bool = false;
	}

	public void Quit(){
		confirmation.interactable = true;
		confirmation.blocksRaycasts = true;
		confirmation.alpha = 1;
		child.active = true;

		my_group.interactable = false;
		my_group.blocksRaycasts = false;
		my_group.alpha = 0;
	}

	public void Continue(){
		my_bool = false;
		my_group.interactable = false;
		my_group.blocksRaycasts = false;
		my_group.alpha = 0;
		foreach(GuiWeapon g in wp)
			g.ft_check_bool();
		gM_obj.pause(false);
	}
	
	public void blockWeapon(){
		foreach(GuiWeapon g in wp)
			g.move = false;
	}

	public void releaseWeapon(){
		foreach(GuiWeapon g in wp)
			g.ft_check_bool();
	}
	// Update is called once per frame
	void Update () {
		if (!child.active && Input.GetKeyDown (KeyCode.Escape)) {
			my_bool = !my_bool;
			gM_obj.pause(my_bool);
			my_group.interactable = my_bool;
			my_group.blocksRaycasts = my_bool;
			if (my_bool){
				my_group.alpha = 1;
				blockWeapon();
			}
			else{
				my_group.alpha = 0;
				releaseWeapon();
			}

		}
	}
}
