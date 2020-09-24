using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    bool bPushCheck = false;
    float fDt = 0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (bPushCheck == true)
        {
            fDt += Time.deltaTime;
        }
        if (fDt > 2.0f)
        {
            GameSateData.I.SaveData();
            Application.LoadLevel("stGame");
        }
	}

    void OnClick()
    {
        if (bPushCheck == false)
        {
            bPushCheck = true;
        }
    }
}
