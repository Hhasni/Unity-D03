using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIPlayer : MonoBehaviour {

	public GameObject	Energy;
	public GameObject	Life;
	public gameManager	gM_obj;
	// Use this for initialization
	void Start () {
		Energy.GetComponent<Text>().text = gM_obj.playerEnergy.ToString();
		Life.GetComponent<Text>().text = gM_obj.playerHp.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		Energy.GetComponent<Text>().text = gM_obj.playerEnergy.ToString();
		Life.GetComponent<Text>().text = gM_obj.playerHp.ToString();
	}

}
