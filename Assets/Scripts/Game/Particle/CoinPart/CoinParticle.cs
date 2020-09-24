using UnityEngine;
using System.Collections;

public class CoinParticle : MonoBehaviour {

    Transform MyTransform;
    tk2dAnimatedSprite MyAniSprite = null;
	// Use this for initialization
	void Start () {
        MyTransform = transform;
        MyAniSprite = MyTransform.GetComponent<tk2dAnimatedSprite>();

        MyTransform.gameObject.SetActiveRecursively(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (MyTransform.gameObject.active == true)
        {
            if (MyAniSprite.isPlaying() == false)
            {
                MyAniSprite.SetFrame(0);
                MyTransform.gameObject.SetActiveRecursively(false);
            }
            if (MyAniSprite.spriteId == MyAniSprite.GetSpriteIdByName("smoke4"))
            {
                MyAniSprite.SetFrame(0);
                MyTransform.gameObject.SetActiveRecursively(false);
            }
        }
	}
}
