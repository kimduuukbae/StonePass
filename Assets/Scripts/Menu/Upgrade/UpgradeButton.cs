using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {

    UISprite UpgradeTarget = null;
    ItemTimeUpgrade ItemTimeUpgrade = null;
    ItemFastShowUpgrade ItemFastShowUpgrade = null;
    FastStartUpgrade FastStartUpgrade = null;
    Manager ManagerScripts = null;
	// Use this for initialization
	void Start () {
        UpgradeTarget = GameObject.Find("UpgradeTarget").GetComponent<UISprite>();
        ItemTimeUpgrade = GameObject.Find("ItemTimeUpgrade").GetComponent<ItemTimeUpgrade>();
        ItemFastShowUpgrade = GameObject.Find("ItemFastShowUpgrade").GetComponent<ItemFastShowUpgrade>();
        FastStartUpgrade = GameObject.Find("FastStartUpgrade").GetComponent<FastStartUpgrade>();
        ManagerScripts = GameObject.Find("Manager(Clone)").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        /// 부스트 아이템 _빠른시작_///
        if (UpgradeTarget.spriteName == "Fast Start")
        {
            if (FastStartUpgrade.UpgradeWantCoin < ManagerScripts.fCoinNum)
            {
                ManagerScripts.fCoinNum -= FastStartUpgrade.GetComponent<FastStartUpgrade>().UpgradeWantCoin;
                FastStartUpgrade.LevelVersion += 1;
                Instantiate(Resources.Load("Prefabs/UpgradeSuccessView"), new Vector3(0.0f, 0.0f, -0.358586f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                GameSateData.I.SaveData();
            }
        }
        /// 부스트 아이템 _ 여기까지 _ ///
        /// 
        /// 
        ///아이템 시간 업그레이드 목록///
        if (UpgradeTarget.spriteName == "ItemTime")
        {
                if (ItemTimeUpgrade.UpgradeWantCoin < ManagerScripts.fCoinNum)
                {
                    ManagerScripts.fCoinNum -= ItemTimeUpgrade.GetComponent<ItemTimeUpgrade>().UpgradeWantCoin;
                    ItemTimeUpgrade.UpgradeWantCoin += 200;
                    ItemTimeUpgrade.LevelVersion += 1;
                    Instantiate(Resources.Load("Prefabs/UpgradeSuccessView"), new Vector3(0.0f, 0.0f, -0.358586f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    GameSateData.I.SaveData();
                }
        }
        if (UpgradeTarget.spriteName == "ScoreBala")
        {
                if (ItemFastShowUpgrade.UpgradeWantCoin < ManagerScripts.fCoinNum)
                {
                    ManagerScripts.fCoinNum -= ItemTimeUpgrade.GetComponent<ItemTimeUpgrade>().UpgradeWantCoin;
                    ItemFastShowUpgrade.UpgradeWantCoin += 200;
                    ItemFastShowUpgrade.LevelVersion += 1;
                    Instantiate(Resources.Load("Prefabs/UpgradeSuccessView"), new Vector3(0.0f, 0.0f, -0.358586f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    GameSateData.I.SaveData();
                }
        }
        ///아이템 시간 업그레이드 _ 여기까지 _ ///
    }
}
