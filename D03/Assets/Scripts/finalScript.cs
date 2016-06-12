using UnityEngine;
using System.Collections;

public class finalScript : MonoBehaviour {


	private RectTransform plop; 
	// Use this for initialization
	void Start () {
		plop = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		plop.transform.localPosition = new Vector2 (plop.transform.localPosition.x, plop.transform.localPosition.y + 10f * Time.deltaTime);
	}
}
