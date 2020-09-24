using UnityEngine;
using System.Collections;

public class Songoku : MonoBehaviour {

    private Transform MyTransform;
	// Use this for initialization
	void Start () {
        MyTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (MyTransform.position.x > 0.6f)
            MyTransform.Translate(-0.03f,0.0f,0.0f);
	}
}
