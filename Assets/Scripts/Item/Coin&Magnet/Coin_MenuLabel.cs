using UnityEngine;
using System.Collections;

public class Coin_MenuLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetComponent<UILabel>().text = GameObject.Find("Manager(Clone)").GetComponent<Manager>().fCoinNum.ToString();
	}
}
