using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

    bool bPauseCheck = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bPauseCheck == false)
            {
                GameObject.Find("Manager(Clone)").GetComponent<Manager>().Set_Monster_Speed(0.0f);
                Time.timeScale = 0.0f;
                GameObject.Find("Option").transform.position = new Vector3(150.21f, -0.4f, -5.36f);
                bPauseCheck = true;
            }
            else
            {
                GameObject.Find("Manager(Clone)").GetComponent<Manager>().Return_Monster_Speed();
                Time.timeScale = 1.0f;
                GameObject.Find("Option").transform.position = new Vector3(300.22f, -0.5f, -5.36f);
                bPauseCheck = false;
            }
        }
	}
    void OnClick()
    {
        if (bPauseCheck == false)
        {
            GameObject.Find("Manager(Clone)").GetComponent<Manager>().Set_Monster_Speed(0.0f);
            Time.timeScale = 0.0f;
            GameObject.Find("Option").transform.position = new Vector3(150.21f, -0.4f, -5.36f);
            bPauseCheck = true;
        }
        else
        {
            GameObject.Find("Manager(Clone)").GetComponent<Manager>().Return_Monster_Speed();
            Time.timeScale = 1.0f;
            GameObject.Find("Option").transform.position = new Vector3(300.22f, -0.5f, -5.36f);
            bPauseCheck = false;
        }
    }
}
