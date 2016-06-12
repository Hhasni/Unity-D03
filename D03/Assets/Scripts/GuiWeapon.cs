using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiWeapon : MonoBehaviour {

	public towerScript 	ToweClass;
	public GameObject	energy;
	public GameObject 	damage;
	public GameObject 	dps;
	public GameObject 	range;
	public gameManager	gM_obj;
	public Image		logo;
	public bool 		move;
	public int 			bkp_energy;
	// Use this for initialization
	void Start () {
		move = true;
		bkp_energy = gM_obj.playerEnergy;
		logo = GetComponentInChildren<Image> ();
		ToweClass = GetComponentInChildren<towerScript> ();
		energy.GetComponent<Text>().text = ToweClass.energy.ToString();
		damage.GetComponent<Text>().text = ToweClass.damage.ToString();
		dps.GetComponent<Text>().text = ToweClass.fireRate.ToString();
		range.GetComponent<Text>().text = ToweClass.range.ToString();
	}

	public void ft_check_bool(){
		if (move && ToweClass.energy > gM_obj.playerEnergy) {
			move = false;
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, 0.39f);
		} else if (!move && ToweClass.energy <= gM_obj.playerEnergy) {
			logo.color = new Color (logo.color.r, logo.color.g, logo.color.b, 1);
			move = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bkp_energy != gM_obj.playerEnergy) {
			bkp_energy = gM_obj.playerEnergy;
			ft_check_bool();
		}
	//	Debug.Log ("ENERGY OF THE TOWER: " + ToweClass.energy);
	}
}
