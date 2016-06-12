using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireBall : MonoBehaviour {
	
	public 	int 		energy;
	private float 		timer;
	public 	bool 		move;
	public Image		logo;
	// Use this for initialization
	void Start () {
		logo = gameObject.transform.GetChild(0).GetComponentInChildren<Image> ();
		energy = 1;
		move = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 60) {
			timer = 0;
			move = true;
		}
		if (move)
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, 1f);
		else
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, 0.39f);
		timer += Time.deltaTime;
	}
}
