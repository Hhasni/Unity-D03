using UnityEngine;
using System.Collections;

public class FireEmergency : MonoBehaviour {

	public GameObject	explosion;
	private bool		already;

	// Use this for initialization
	void Start () {
		already = false;
	}

	IEnumerator WaitAndDestroy()
	{
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
		
	void OnTriggerEnter2D(Collider2D col){

		//Debug.Log ("COLLISION WITH : " + col.gameObject.tag);
		if (!already) {
			if (col.gameObject.tag == "bot" || col.gameObject.tag == "boss" || col.gameObject.tag == "flybot") {
				col.gameObject.GetComponent<ennemyScript> ().hp -= 1000;
				already = true;
			}
			Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
			StartCoroutine (WaitAndDestroy ());
		}
	}

//	void OnTriggerEnter2D(Collider2D col){
//		if(col.gameObject.tag == "bot" || col.gameObject.tag == "boss" || col.gameObject.tag == "flybot" ) {
	//		Debug.Log ("tigger enter : " + col.gameObject.tag);
		
//			col.gameObject.GetComponent<ennemyScript>().hp -= 1000;
		//	Destroy (this);

	// Update is called once per frame
	void Update () {
		//Destroy (gameObject);
	}
}
