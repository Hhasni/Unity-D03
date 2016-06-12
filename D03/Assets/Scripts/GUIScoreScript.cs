using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIScoreScript : MonoBehaviour {
	
	public gameManager		gM_Obj;
	public Text				Rank;
	public Text				Score;
	public ennemySpawner	spawner;
	private CanvasGroup		my_group;
	private int				my_score;
	// Use this for initialization
	void Start () {
		my_group = GetComponent<CanvasGroup> ();
	}

	public void next_lvl(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	void ft_rank(){
		my_score = gM_Obj.score + (gM_Obj.playerHp * 10000) + (gM_Obj.playerEnergy * 1000);
		string my_rank = "";
		Debug.Log (my_score.ToString());
		if (my_score >= 1350000)
			my_rank = "SSS+";
		else if (my_score >= 1300000)
			my_rank = "SSS";
		else if (my_score >= 1200000)
			my_rank = "SS";
		else if (my_score >= 1100000)
			my_rank = "S";
		else if (my_score >= 1000000)
			my_rank = "AAA";
		else if (my_score >= 950000)
			my_rank = "AA";
		else if (my_score >= 900000)
			my_rank = "A";
		else if (my_score >= 800000)
			my_rank = "B";
		else if (my_score >= 700000)
			my_rank = "C";
		else if (my_score >= 600000)
			my_rank = "D";
		else if (my_score >= 500000)
			my_rank = "E";
		else
			my_rank = "F";
		Rank.text = Rank.text + " " + my_rank;
		Score.text = Score.text + " " + my_score;
	}

	// Update is called once per frame
	void Update () {
		if (my_group.alpha == 0 && spawner.isEmpty && spawner.gameObject.transform.childCount == 0) {
			ft_rank();
			my_group.interactable = true;
			my_group.blocksRaycasts = true;
			my_group.alpha = 1;
		}
	}
}
