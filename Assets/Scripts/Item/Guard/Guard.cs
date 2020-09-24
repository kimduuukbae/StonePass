using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour
{

    public bool bGuardShow = false;
    bool GuardCheck = false;
    private Transform MyTransform;
    private Transform HeroPos;
    float CoolTime = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
    MouseScripts scHeroTag = null;
    float fDt = 0.0f;
    public float fGuardDeletePlane = 3.0f;
    public bool bBoostItem = false;
    // Use this for initialization
    void Start()
    {
        MyTransform = transform;
        MyTransform.localScale = new Vector3(0.0f, 6.0f, 1.0f);
        HeroPos = GameObject.Find("HeroSprite").transform;
        scHeroTag = GameObject.Find("HeroSprite").GetComponent<MouseScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bGuardShow)
        { MyTransform.localScale = new Vector3(3.0f, 5.0f, 1.0f); bGuardShow = false; GuardCheck = true; }

        if (GuardCheck == true)
        {
            fDt += Time.deltaTime;
            MyTransform.position = new Vector3(HeroPos.position.x, HeroPos.position.y, HeroPos.position.z - 0.5f);

            if (bBoostItem == false)
            {
                if (fDt > (4.0f + (CoolTime * 0.1f)))
                {
                    fDt = 0.0f;
                    scHeroTag.ReturnHeroTag();
                    Destroy(GameObject.Find("GuardObject(Clone)"));
                }
            }
            else
            {
                if (fDt > (8.0f + (CoolTime * 0.1f)))
                {
                    fDt = 0.0f;
                    scHeroTag.ReturnHeroTag();
                    Destroy(GameObject.Find("GuardObject(Clone)"));
                }
            }
        }
    }
}
