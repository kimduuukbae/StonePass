using UnityEngine;
using System.Collections;

public class Coin_Magnet : MonoBehaviour {

    Transform TfHeroPos;
    Manager scMagnetCheck = null;
    Transform MyTransform;
    tk2dSprite MySprite = null;
    float fDt = 0.0f;
    float nPos = 0.0f;
    bool bOnce = false;
    float PosY = 0.0f;
	// Use this for initialization
	void Start () {
        TfHeroPos = GameObject.Find("HeroSprite").transform;
        scMagnetCheck = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        MyTransform = transform;
        MySprite = MyTransform.GetComponent<tk2dSprite>();
        
	}
	
	void Update () {
        MagnetUpdate();
	}

    void MagnetUpdate()
    {
        if (scMagnetCheck.bStopMakeItem == true)
        {
            fDt += Time.deltaTime;
            if (fDt < 0.5f)
            {
                nPos += Time.deltaTime * 10.0f;
                PosY = Mathf.Sin(nPos * 10.0f) * Mathf.Pow(0.5f, nPos);
                MyTransform.position = new Vector3(MyTransform.position.x + PosY, MyTransform.position.y , MyTransform.position.z + PosY);
                One();
            }
            else
            {
                MyTransform.position = Vector3.Lerp(MyTransform.position, TfHeroPos.position, Time.deltaTime * 8.0f);
            }
        }
    }

    void One()
    {
        if (bOnce == false)
        {
            MySprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            bOnce = true;
        }
    }
}
