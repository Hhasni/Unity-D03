using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {

	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	// Use this for initialization
	void Start () {
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}

	public void resetCursor(){
		Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
	}

	public void changeCursor (Texture2D txt){
		Vector2 cursorHotspot = new Vector2 (txt.width / 2, txt.height / 2);
		Cursor.SetCursor(txt, cursorHotspot, CursorMode.Auto);
	}
	// Update is called once per frame
	void Update () {
	}
}
