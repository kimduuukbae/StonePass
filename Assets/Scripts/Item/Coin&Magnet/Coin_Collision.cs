using UnityEngine;
using System.Collections;

public class Coin_Collision : MonoBehaviour {

    Coin_Label scCoin_Label = null;
    tk2dSprite MySprite = null;
    float fMyAlpha = 0.0f;
    float fDt = 0.0f;
    bool bAlphaCheck = false;
    bool bDeleteCheck = false;
	// Use this for initialization
	void Start () {
        transform.Translate(Random.Range(3.0f, -4.0f), Random.Range(3.0f, -3.0f), 0.0f);
        scCoin_Label = GameObject.Find("Coin_Label").GetComponent<Coin_Label>();
        MySprite = transform.GetComponent<tk2dSprite>();
	}
	
	// Update is called once per frame
	void Update () {
        if (bDeleteCheck == false)
        {
            if (bAlphaCheck == false)
            {
                fMyAlpha += Time.deltaTime * 2;
                MySprite.color = new Color(1.0f, 1.0f, 1.0f, fMyAlpha);
                if (fMyAlpha > 0.99f)
                    bAlphaCheck = true;
            }
            else
            {
                fDt += Time.deltaTime;
                if (fDt > 1.0f)
                {
                    fMyAlpha -= Time.deltaTime;
                    MySprite.color = new Color(1.0f, 1.0f, 1.0f, fMyAlpha);
                    if (fMyAlpha < 0.01f)
                        bDeleteCheck = true;
                }
            }
        }
        else
        {
            Destroy(transform.gameObject);
        }
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Finish" || other.transform.tag == "Sabotua")
        {
            scCoin_Label.CoinNum += 1;
            GameObject.Find("Manager(Clone)").GetComponent<Manager>().fCoinNum += 1;
            Destroy(transform.gameObject);
        }
    }
}
