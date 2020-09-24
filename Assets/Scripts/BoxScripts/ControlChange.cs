using UnityEngine;
using System.Collections;

public class ControlChange : MonoBehaviour {

    Transform MyTransform;
    MouseScripts scMouseScrip = null;
    UISlicedSprite[] AlphaTag = new UISlicedSprite[2];
	// Use this for initialization
	void Start () {
        MyTransform = transform;
        scMouseScrip = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();
        AlphaTag[0] = GameObject.Find("TouchImage").GetComponent<UISlicedSprite>();
        AlphaTag[1] = GameObject.Find("SensorImage").GetComponent<UISlicedSprite>();
        AlphaTag[1].color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnClick()
    {
        if (MyTransform.name == "GoToMenu")
        {
            scMouseScrip.bOption = true;
            AlphaTag[0].color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            AlphaTag[1].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            scMouseScrip.bOption = false;
            AlphaTag[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            AlphaTag[1].color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }
}
