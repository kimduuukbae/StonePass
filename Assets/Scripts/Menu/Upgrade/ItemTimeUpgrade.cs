using UnityEngine;
using System.Collections;

public class ItemTimeUpgrade : MonoBehaviour {

    public int LevelVersion = 1;
    public int UpgradeWantCoin = 400;
    UILabel LevelLabel = null;
    UILabel UpgradeInformation = null;
    UILabel WantCoin = null;
    UISprite UpgradeTarget = null;
	// Use this for initialization
	void Start () {
        LevelLabel = GameObject.Find("LevelLabel").GetComponent<UILabel>();
        UpgradeInformation = GameObject.Find("UpgradeInformation").GetComponent<UILabel>();
        UpgradeTarget = GameObject.Find("UpgradeTarget").GetComponent<UISprite>();
        WantCoin = GameObject.Find("WantCoin").GetComponent<UILabel>();
        LevelVersion = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
        UpgradeWantCoin = 400 + (LevelVersion * 200);
	}
	
	// Update is called once per frame
	void Update () {
        if (UpgradeTarget.spriteName == "ItemTime")
        {
            LevelLabel.text = "LV : " + LevelVersion.ToString();
            UpgradeInformation.text = "아이템 지속시간이\n" + "증가합니다.";
            WantCoin.text = UpgradeWantCoin.ToString();
        }
	}

    void OnClick()
    {
        UpgradeTarget.spriteName = "ItemTime";
    }
}
