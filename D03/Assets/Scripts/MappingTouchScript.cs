using UnityEngine;
using System.Collections;

public class MappingTouchScript : MonoBehaviour {

	public GameObject 			current;
	public gameManager			gM_obj;
	public Texture2D[] 			cursorTexture;
	public GameObject[] 		wp;
	public CursorScript	cursor;
	// Use this for initialization
	void Start () {
		cursor = Camera.main.GetComponent<CursorScript> ();
		gM_obj = GameObject.Find ("GameManager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			cursor.changeCursor (cursorTexture [0]);
			current = wp[0];
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)){
			cursor.changeCursor (cursorTexture[1]);
			current = wp[1];
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)){
			cursor.changeCursor (cursorTexture[2]);
			current = wp[2];
		}
		if (Input.GetMouseButtonDown (0) && current != null) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
			if (hit.collider != null) {
				if (hit.collider.tag == "empty" && gM_obj.playerEnergy >= current.GetComponent<towerScript> ().energy) {
					gM_obj.playerEnergy -= current.GetComponent<towerScript> ().energy;
					current.transform.position = new Vector3 (0, 0, 0);
					Instantiate (current, hit.collider.gameObject.transform.position, gameObject.transform.rotation);
				}
			}
			current = null;
			cursor.resetCursor ();


			//		RaycastHit2D[] hits = Physics2D.RaycastAll (ray.origin, ray.direction, Mathf.Infinity);
			//		foreach (RaycastHit2D hit in hits){
			///			if (hit.collider != null){
			//				if (hit.collider.tag == "empty" && gM_obj.playerEnergy >= current_script.energy) {
			//					gM_obj.playerEnergy -= current_script.energy;
			//					current.transform.position = new Vector3 (0, 0, 0);
			//					Instantiate (current, hit.collider.gameObject.transform.position, gameObject.transform.rotation);
			//				}
			//			}
			//		}
		} else if (Input.GetMouseButtonDown (1)) {
			current = null;
			cursor.resetCursor ();
		}
	}
}
