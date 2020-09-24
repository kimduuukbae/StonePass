using UnityEngine;
using System.Collections;

public class SetAlpha_Logo : MonoBehaviour {

    bool bCheckLogo = false;
    float fAlpha = 0.0f;
    float fWaitfAlpha = 0.0f;
    LogoScene scCheck_ToLogoScene = null;
    UISprite Mysprite = null;
	// Use this for initialization
	void Start () {
        scCheck_ToLogoScene = GameObject.Find("Main Camera").GetComponent<LogoScene>();
        Mysprite = transform.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
        if (scCheck_ToLogoScene.bAlphaCheck == true)
        {
            if (bCheckLogo == false)
            {
                fAlpha += Time.deltaTime / 1.5f;
                Mysprite.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
                if (fAlpha > 1.0f)
                    bCheckLogo = true;
            }
            else
            {
                fWaitfAlpha += Time.deltaTime;

                if (fWaitfAlpha > 1.0f)
                {
                    fAlpha -= Time.deltaTime / 1.5f;
                    Mysprite.color = new Color(1.0f, 1.0f, 1.0f, fAlpha);
                    if (fAlpha < 0.0f)
                    {
                        scCheck_ToLogoScene.bAlphaCheck = false;
                        scCheck_ToLogoScene.NextScene();
                    }
                }
            }
        }
	}
}
