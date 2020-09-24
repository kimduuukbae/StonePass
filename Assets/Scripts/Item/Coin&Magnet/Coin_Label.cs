using UnityEngine;
using System.Collections;

public class Coin_Label : MonoBehaviour {

    public int CoinNum = 0;
    
	// Use this for initialization
	void Start () {
        if (transform.tag == "Player")
            transform.GetComponent<UILabel>().text = GameObject.Find("Manager(Clone)").GetComponent<Manager>().fCoinNum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        CoinUpdate();

	}
    void CoinUpdate()
    {
        if (transform.tag != "Player")
            transform.GetComponent<UILabel>().text = CoinNum.ToString();
    }
}
