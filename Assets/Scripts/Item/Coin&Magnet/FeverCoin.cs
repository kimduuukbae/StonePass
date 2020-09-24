using UnityEngine;
using System.Collections;

public class FeverCoin : MonoBehaviour {

    Coin_Label scCoin_Label = null;
    Manager scManager = null;
    Transform MyTransform;
    FeverObj scFeverObj = null;
    float fDt = 0.0f;
    int nType = 0;
    bool bCheck = false;
	// Use this for initialization
	void Start () {
        scCoin_Label = GameObject.Find("Coin_Label").GetComponent<Coin_Label>();
        scManager = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
        scFeverObj = GameObject.Find("FeverCoinObj").GetComponent<FeverObj>();
        MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        fDt += Time.deltaTime;

        if (fDt > 3.0f)
        {
            scFeverObj.QuitActive(transform.gameObject);
            fDt = 0.0f;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Finish" || other.transform.tag == "Sabotua")
        {
            scCoin_Label.CoinNum += 1;
            scManager.fCoinNum += 1;
            scFeverObj.QuitActive(transform.gameObject);
        }
    }
}
