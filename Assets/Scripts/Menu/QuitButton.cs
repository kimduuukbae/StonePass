using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

    public GameObject PopUpExit = null;
    Vector3 PopupScale;
    float[] VectorfXY = new float[2];
    public bool bPopupShow = false;
	// Use this for initialization
	void Start () {
        PopUpExit = GameObject.Find("ExitPopUp");
        PopupScale = PopUpExit.transform.localScale;
        PopUpExit.transform.localScale = new Vector3(0.0f, 0.0f, PopupScale.z);
        PopUpExit.gameObject.SetActiveRecursively(false);
        VectorfXY[0] = 0.0f; // X
        VectorfXY[1] = 0.0f; // Y

}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bPopupShow == false)
            {
                VectorfXY[0] = 0.0f; // X
                VectorfXY[1] = 0.0f; // Y
                PopUpExit.gameObject.SetActiveRecursively(true);
                bPopupShow = true;
            }
        }

        if (bPopupShow == true)
        {
            if ( PopupScale.x >= VectorfXY[0] )
                VectorfXY[0] += ( PopupScale.x * 0.1f);
            if ( PopupScale.y >= VectorfXY[1] )
                VectorfXY[1] += ( PopupScale.y * 0.1f);

            Debug.Log("0:" + VectorfXY[0]);
            Debug.Log("0:" + VectorfXY[1]);

            PopUpExit.transform.localScale = new Vector3(VectorfXY[0], VectorfXY[1], PopupScale.z);
        }
	}
}
