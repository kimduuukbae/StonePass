using UnityEngine;
using System.Collections;

public class ScoreLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (transform.name == "Ranked_list_Label_1")
        {
            transform.GetComponent<UILabel>().text = "1등 : " + GameSateData.I.myData.manage.rank_1.ToString() + " 점";
        }
        else if (transform.name == "Ranked_list_Label_2")
        {
            transform.GetComponent<UILabel>().text = "2등 : " + GameSateData.I.myData.manage.rank_2.ToString() + " 점";
        }
        else if (transform.name == "Ranked_list_Label_3")
        {
            transform.GetComponent<UILabel>().text = "3등 : " + GameSateData.I.myData.manage.rank_3.ToString() + " 점";
        }
        else if (transform.name == "Ranked_list_Label_4")
        {
            transform.GetComponent<UILabel>().text = "4등 : " + GameSateData.I.myData.manage.rank_4.ToString() + " 점";
        }
        else if (transform.name == "Ranked_list_Label_5")
        {
            transform.GetComponent<UILabel>().text = "5등 : " + GameSateData.I.myData.manage.rank_5.ToString() + " 점";
        }
	}
}
