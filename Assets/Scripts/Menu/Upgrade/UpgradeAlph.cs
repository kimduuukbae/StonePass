using UnityEngine;
using System.Collections;

public class UpgradeAlph : MonoBehaviour {
    Color TransColor;
    float fDt = 0.0f;
    bool bAlphaPattern = false;
	// Use this for initialization
	void Start () {
        TransColor = transform.GetComponent<UISprite>().color;
        TransColor.a = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (bAlphaPattern == false)
        {
            if (fDt > 0.7f)
            {
                fDt = 0.0f;
                bAlphaPattern = true;
            }
            else
            {
                fDt += Time.deltaTime;
                TransColor.a += Time.deltaTime * 2;
                transform.GetComponent<UISprite>().color = new Color(TransColor.r, TransColor.g, TransColor.b, TransColor.a);
            }
        }
        else
        {
            if (fDt > 0.7f)
            {
                Destroy(GameObject.Find("UpgradeSuccessView(Clone)"));
            }
            else
            {
                fDt += Time.deltaTime;
                TransColor.a -= Time.deltaTime * 2;
                transform.GetComponent<UISprite>().color = new Color(TransColor.r, TransColor.g, TransColor.b, TransColor.a);
            }
        }
	}
}
