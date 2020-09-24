using UnityEngine;
using System.Collections;

public class LogoScene : MonoBehaviour {
    public bool bAlphaCheck = false;
    bool bCheckNextScene = false;
    float fDt = 0.0f;
	// Use this for initialization
	void Start () {
        if (GameObject.Find("Manager(Clone)") == null) {
            Instantiate(Resources.Load("prefabs/Manager"), new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (bAlphaCheck == false)
        {
            fDt += Time.deltaTime;
            if (fDt > 1.5f)
            {
                if (bCheckNextScene == true)
                {
                    Application.LoadLevel("stGame");
                }
                else
                {
                    bAlphaCheck = true;
                    fDt = 0.0f;
                }
            }
        }
	}

    public void NextScene()
    {
        bCheckNextScene = true;
    }
}
