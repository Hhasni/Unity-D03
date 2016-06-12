using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class RadialButtonOverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	public	bool			isInside;
	// Use this for initialization
	void Start () {
		isInside = false;	
	}

	public void OnPointerEnter(PointerEventData eventData){
		isInside = true;
	}

	public void OnPointerExit(PointerEventData eventData){
		isInside = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
