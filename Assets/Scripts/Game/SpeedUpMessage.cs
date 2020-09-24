using UnityEngine;
using System.Collections;

public class SpeedUpMessage : MonoBehaviour {

    Color TransColor;
    float fDt = 0.0f;
    bool bAlphaPattern = false;
    tk2dSprite MySprite = null;
	// Use this for initialization
	void Start () {
        TransColor = transform.GetComponent<tk2dSprite>().color;
        TransColor.a = 0.0f;
        MySprite = transform.GetComponent<tk2dSprite>();
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
                TransColor.a += Time.deltaTime * 2 ;
                MySprite.color = new Color(TransColor.r, TransColor.g, TransColor.b, TransColor.a);
            }
        }
        else
        {
            if (fDt > 0.7f)
            {
                Destroy(transform.gameObject);
            }
            else
            {
                fDt += Time.deltaTime;
                TransColor.a -= Time.deltaTime * 2 ;
                MySprite.color = new Color(TransColor.r, TransColor.g, TransColor.b, TransColor.a);
            }
        }
	}
}
