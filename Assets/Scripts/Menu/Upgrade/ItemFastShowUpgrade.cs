using UnityEngine;
using System.Collections;

public class ItemFastShowUpgrade : MonoBehaviour {

    public int LevelVersion = 1;
    public int UpgradeWantCoin = 400;
    UILabel LevelLabel = null;
    UILabel UpgradeInformation = null;
    UILabel WantCoin = null;
    UISprite UpgradeTarget = null;

    void Awake()
    {
        UpgradeTarget = GameObject.Find("UpgradeTarget").GetComponent<UISprite>();
    }
	void Start () {
        LevelLabel = GameObject.Find("LevelLabel").GetComponent<UILabel>();
        UpgradeInformation = GameObject.Find("UpgradeInformation").GetComponent<UILabel>();
        WantCoin = GameObject.Find("WantCoin").GetComponent<UILabel>();
        LevelVersion = GameSateData.I.myData.manage.ItemFastShowUpgradeLevel;
        UpgradeWantCoin = 400 + (LevelVersion * 200);
	}
	
	// Update is called once per frame
	void Update () {
        if (UpgradeTarget.spriteName == "ItemRegenation")
        {
            LevelLabel.text = "LV : " + LevelVersion.ToString();
            UpgradeInformation.text = "아이템 등장시간이\n" + "빨라집니다.";
            WantCoin.text = UpgradeWantCoin.ToString();
        }
	}

    void OnClick()
    {
        UpgradeTarget.spriteName = "ItemRegenation";
    }
}
