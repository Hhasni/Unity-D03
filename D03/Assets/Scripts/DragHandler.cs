using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler , IDragHandler, IEndDragHandler, IPointerClickHandler{
	public static GameObject 	current;
	Vector3 					PosS;
	public gameManager			gM_obj;
	public static towerScript 	current_script;
	public bool 				isDragable;
	public SpriteRenderer		range;

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData){
	//	Debug.Log ("YEEES");
	}
	#endregion


	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)	{
		GuiWeapon tmp = GetComponentInParent<GuiWeapon> ();
		if (tmp && tmp.move) {
			isDragable = true;
			current = gameObject.transform.GetChild (0).gameObject;
			if  (range != null) 
				range.enabled = true;
			current_script = current.GetComponent<towerScript> ();
			PosS = transform.position;
		} else if (GetComponentInParent<FireBall> () && GetComponentInParent<FireBall> ().move) {
			current = gameObject.transform.GetChild (0).gameObject;
			isDragable = true;
			//GetComponentInParent<FireBall> ().move = false;
			PosS = transform.position;
		}
		else
			isDragable = false;
	}

	#endregion

	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)	{
		if (isDragable) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
		}
	}
	
	#endregion

	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)	{
		int i = 0;
		RaycastHit2D bkp;
		if (isDragable) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.RaycastAll (ray.origin, ray.direction, Mathf.Infinity);
			foreach (RaycastHit2D hit in hits){
				if (hit.collider != null){
					Debug.Log(hit.collider.tag);
					if (hit.collider.tag == "empty"){
						bkp = hit;
						i++;
					}
					if (hit.collider.tag == "tower"){
						i--;
					}
					if (current_script == null && current){
						GetComponentInParent<FireBall> ().move = false;
						current.transform.position = new Vector3 (0, 0, 0);
						GameObject tp = Instantiate (current, hits[0].collider.gameObject.transform.position, gameObject.transform.rotation) as GameObject;
						tp.SetActive(true);
						current = null;
						transform.position = PosS;
						return;
					}
				}
			}
			if (i == 1 && current_script && gM_obj.playerEnergy >= current_script.energy) {
				gM_obj.playerEnergy -= current_script.energy;
				if (range != null)
					range.enabled = false;
				current.transform.position = new Vector3 (0, 0, 0);
				Instantiate (current, bkp.collider.gameObject.transform.position, gameObject.transform.rotation);
			}

			current = null;
			current_script = null;
			transform.position = PosS;
		}
	}

	#endregion

}
