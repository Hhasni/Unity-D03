using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerUpgradeManager : MonoBehaviour{
	
	private CanvasGroup		my_canvas;
	private gameManager		gM_Obj;
	private RectTransform 	my_rectTransform;
	private GameObject 		towerSelected;
	private int				cost;
	private int 			gain;
	public 	Text			textUpgrade;
	public 	Text			textDowngrade;
	public 	Text			textSell;
	private	bool 			active;
	private	Button[] 		buttons;

	// Use this for initialization
	void Start () {
		active = false;
		cost = 0;
		gain = 0;
		gM_Obj = GameObject.Find ("GameManager").GetComponent<gameManager>();
		my_canvas = GetComponent<CanvasGroup> ();
		my_rectTransform = gameObject.transform.GetChild (0).GetComponent<RectTransform> ();
		buttons = GetComponentsInChildren<Button> ();
	}

	void ft_active(){
		active = true;
		if (towerSelected.GetComponentInParent<towerScript> ().upgrade != null) {
			cost = towerSelected.GetComponentInParent<towerScript> ().upgrade.GetComponent<towerScript> ().energy;
			textUpgrade.text = cost.ToString ();
		}
		gain = towerSelected.GetComponentInParent<towerScript> ().energy / 2;
		if (towerSelected.GetComponentInParent<towerScript> ().downgrade == null)
			textSell.text = gain.ToString ();
		else
			textDowngrade.text = gain.ToString ();
		my_rectTransform.transform.position = towerSelected.transform.position;
		my_canvas.alpha = 1 - my_canvas.alpha;
		my_canvas.blocksRaycasts = !my_canvas.blocksRaycasts;
		my_canvas.interactable = !my_canvas.interactable;
	}

	public void close(){
		textSell.text = "";
		textUpgrade.text = "";
		active = false;
		my_canvas.alpha = 0;
		my_canvas.blocksRaycasts = false;
		my_canvas.interactable = false;
		towerSelected = null;
	}

	public void upgrade(){
		if (gM_Obj.playerEnergy >= cost){
			Instantiate (towerSelected.GetComponentInParent<towerScript> ().upgrade, towerSelected.transform.position, towerSelected.transform.rotation);
			Destroy(towerSelected.transform.parent.gameObject);
			gM_Obj.playerEnergy -= cost;
			close();
		}
	}
		
	public void sell(){
	//	int tmp = towerSelected.GetComponentInParent<towerScript> ().energy;
		if (gain > 0)
			gM_Obj.playerEnergy += gain;
		Destroy(towerSelected.transform.parent.gameObject);
		close();
	}

	public void downgrade(){
		if (gain > 0)
			gM_Obj.playerEnergy += gain;
		Instantiate (towerSelected.GetComponentInParent<towerScript> ().downgrade, towerSelected.transform.position, towerSelected.transform.rotation);
		Destroy(towerSelected.transform.parent.gameObject);
		close();
	}

	void ft_check_upgradeable(){
		foreach (Button b in buttons) {
			if (b.gameObject.name == "upgrade") {
				if (towerSelected.GetComponentInParent<towerScript> ().upgrade != null && gM_Obj.playerEnergy >= cost)
					b.interactable = true;
				else
					b.interactable = false;
			}
			else if (b.gameObject.name == "downgrade") {
				if (towerSelected.GetComponentInParent<towerScript> ().downgrade != null)
					b.interactable = true;
				else
					b.interactable = false;
			}
			else if (b.gameObject.name == "sell") {
				if (towerSelected.GetComponentInParent<towerScript> ().downgrade == null)
					b.interactable = true;
				else
					b.interactable = false;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (active)
			ft_check_upgradeable ();
		if (Input.GetMouseButtonDown(1)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.RaycastAll (ray.origin, ray.direction, Mathf.Infinity);
			foreach (RaycastHit2D hit in hits){
				if (hit.collider != null){
					if (hit.collider.tag == "tower"){
						towerSelected = hit.collider.gameObject;
						ft_active();
						return;
					}
				}
			}
			close();
		}
	}
}
