using UnityEngine;
using System.Collections;

public class Popup_No : MonoBehaviour {

    QuitButton scPopup = null;
	// Use this for initialization
	void Start () {
        scPopup = GameObject.Find("CreditMenu").GetComponent<QuitButton>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        scPopup.bPopupShow = false;
        scPopup.PopUpExit.SetActiveRecursively(false);
        scPopup.PopUpExit.transform.position = new Vector3(0.0f, 0.0f, scPopup.PopUpExit.transform.position.z);
    }
}
