using UnityEngine;
using System.Collections;

public class RankedReady : MonoBehaviour {

    public GameObject goRankedView = null;
    public GameObject Button_Credit = null;
    GameObject ExitButton = null;
    public GameObject UpgradeView = null;
    public UILabel GamestartLabel = null;


    /// <summary>
    /// UpgradeItemView/////////
    /// </summary> 

    public GameObject ItemTimeUpgrade = null;
    public GameObject UpgradeSideView = null;
    public GameObject LevelLabel = null;
    public GameObject UpgradeInformation = null;
    public GameObject UpgradeTarget = null;
    public GameObject WantCoin = null;
    public GameObject ChangeUpgrade = null;
    public GameObject FastStartUpgrade = null;
    public GameObject RankingPanel = null;
    public GameObject ItemFastShowUpgrade = null;
    /// <summary>
    /// ////////////////////////
    /// </summary>
    Vector3 VecScale;
    Vector3 VecScale_UV;



    public bool bGameCheck = false;
    public bool bSize_Ranked = false;
    public bool bSize_Upgrad = false;
    bool bSize_Ranked_UpDown = false;
    bool bSize_Upgrad_UpDown = false;



    float fSizeX = 0.0f;
    float fSize_UVx = 0.0f;
    float fSize_UVy = 0.0f;
    float fSizeY = 0.0f;
	// Use this for initialization
	void Start () {
        goRankedView = GameObject.Find("RankedView");
        Button_Credit = GameObject.Find("Button_Credit");
        UpgradeView = GameObject.Find("UpgradeView");
        ExitButton = GameObject.Find("ExitButton");
        FastStartUpgrade = GameObject.Find("FastStartUpgrade");
        ItemTimeUpgrade = GameObject.Find("ItemTimeUpgrade");
        UpgradeSideView = GameObject.Find("UpgradeSideView");
        LevelLabel = GameObject.Find("LevelLabel");
        UpgradeInformation = GameObject.Find("UpgradeInformation");
        UpgradeTarget = GameObject.Find("UpgradeTarget");
        WantCoin = GameObject.Find("WantCoin");
        ChangeUpgrade = GameObject.Find("ChangeUpgrade");
        RankingPanel = GameObject.Find("Ranking Panel");
        ItemFastShowUpgrade = GameObject.Find("ItemFastShowUpgrade");
        GamestartLabel = GameObject.Find("GamestartLabel").GetComponent<UILabel>();
        ExitButton.transform.gameObject.SetActiveRecursively(false);
        LevelLabel.transform.gameObject.SetActiveRecursively(false);
        UpgradeInformation.transform.gameObject.SetActiveRecursively(false);
        UpgradeTarget.transform.gameObject.SetActiveRecursively(false);
        WantCoin.transform.gameObject.SetActiveRecursively(false);
        ChangeUpgrade.transform.gameObject.SetActiveRecursively(false);
        ItemTimeUpgrade.transform.gameObject.SetActiveRecursively(false);
        UpgradeSideView.transform.gameObject.SetActiveRecursively(false);
        FastStartUpgrade.transform.gameObject.SetActiveRecursively(false);
        ItemFastShowUpgrade.transform.gameObject.SetActiveRecursively(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (bSize_Ranked == true)
        {
            if (bSize_Ranked_UpDown == false)
                RankedSizeChange_Up();
            else
                RankedSizeChange_Down();
        }
        if (bSize_Upgrad == true)
        {
            if (bSize_Upgrad_UpDown == false)
                UpgradeSizeChange_Up();
            else
                UpgradeSizeChange_Down();
        }
	}

    void OnClick()
    {
        if (bGameCheck == true)
        {
            Application.LoadLevel("stGame");
        }
        if ( bGameCheck == false)
        {
            fSizeX = 512.0f;
            fSizeY = 512.0f;
            fSize_UVx = 0.0f;
            fSize_UVy = 0.0f;
            bSize_Ranked = true;
            VecScale = new Vector3(fSizeX, fSizeY, 1.0f);
            VecScale_UV = new Vector3(fSize_UVx, fSize_UVy, 1.0f);
            Button_Credit.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            bSize_Upgrad = true;
            bGameCheck = true;
            UpgradeView.GetComponent<UISprite>().depth = 8;
            goRankedView.GetComponent<UISprite>().depth = 7;
        }
    }

    void UpgradeSizeChange_Down()
    {

        fSize_UVx -= 230.0f;
        fSize_UVy -= 612.0f;
        if (fSize_UVx < 1.0f)
        {
            bSize_Upgrad = false;
            bSize_Upgrad_UpDown = false;
        }

        VecScale_UV = new Vector3(fSize_UVx, fSize_UVy, 1.0f);

        UpgradeView.transform.localScale = VecScale_UV;
    }

    void RankedSizeChange_Down()
    {
        ExitButton.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        fSizeX += 230.0f;
        fSizeY += 612.0f;

        if (fSizeX > 229.0f)
        {
            bSize_Ranked = false;
            bSize_Ranked_UpDown = false;
            RankingPanel.transform.gameObject.SetActiveRecursively(true);
        }

        VecScale = new Vector3(fSizeX, fSizeY, 1.0f);

        goRankedView.transform.localScale = VecScale;
    }

    void UpgradeSizeChange_Up()
    {
        fSize_UVx += 115.0f;
        fSize_UVy += 330.0f;
        if (fSize_UVx > 130.0f)
        {
            GamestartLabel.text = "게임 시작";
            bSize_Upgrad_UpDown = true;
            bSize_Upgrad = false;
            ExitButton.transform.gameObject.SetActiveRecursively(true);
            ItemTimeUpgrade.transform.gameObject.SetActiveRecursively(true);
            UpgradeSideView.transform.gameObject.SetActiveRecursively(true);
            LevelLabel.transform.gameObject.SetActiveRecursively(true);
            UpgradeInformation.transform.gameObject.SetActiveRecursively(true);
            UpgradeTarget.transform.gameObject.SetActiveRecursively(true);
            WantCoin.transform.gameObject.SetActiveRecursively(true);
            ChangeUpgrade.transform.gameObject.SetActiveRecursively(true);
            FastStartUpgrade.transform.gameObject.SetActiveRecursively(true);
            ItemFastShowUpgrade.transform.gameObject.SetActiveRecursively(true);
            RankingPanel.transform.gameObject.SetActiveRecursively(false);
        }

        VecScale_UV = new Vector3(fSize_UVx, fSize_UVy, 1.0f);

        UpgradeView.transform.localScale = VecScale_UV;
    }

    void RankedSizeChange_Up()
    {

        fSizeX -= 256.0f;
        fSizeY -= 256.0f;

        if (fSizeX < 1.0f)
        {
            bSize_Ranked_UpDown = true;
            bSize_Ranked = false;
        }

        VecScale = new Vector3(fSizeX, fSizeY, 1.0f);

        goRankedView.transform.localScale = VecScale;
    }
}
