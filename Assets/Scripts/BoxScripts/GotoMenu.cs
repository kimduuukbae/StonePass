using UnityEngine;
using System.Collections;

public class GotoMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("stExit");
    }
}
