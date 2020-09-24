using UnityEngine;
using System.Collections;

public class Slow_Guage : MonoBehaviour {
    UIFilledSprite MyFSprite = null;
    MouseScripts LiveHero = null;
    Manager MonsterSpeed = null;
    float fGuage = 0.0f;
    float fDt = 0.0f;
    FeverManager scFeverMng = null;

	void Start () {
        MyFSprite = transform.GetComponent<UIFilledSprite>();
        MonsterSpeed = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        LiveHero = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();
        scFeverMng = GameObject.Find("Main Camera").GetComponent<FeverManager>();
	}
	
	void Update () {

        fDt += Time.deltaTime;

        if (LiveHero.GetHeroLive() == false && fDt > 0.2f)
        {
            UpdateGuage();
        }
	}

    void UpdateGuage()
    {
        if (fGuage > 0.99f)
        {
            fGuage = 0.0f;
            scFeverMng.DestroyMessage();
            MyFSprite.fillAmount = fGuage;
        }
        else
        {
            fGuage += 0.005f;
            MyFSprite.fillAmount = fGuage;
            fDt = 0.0f;
        }
    }
}
