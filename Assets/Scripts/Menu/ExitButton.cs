using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    RankedReady ImageButton = null;
	// Use this for initialization
	void Start () {
        ImageButton = GameObject.Find("Button_gamestart").GetComponent<RankedReady>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        ImageButton.bSize_Ranked = true;
        ImageButton.bSize_Upgrad = true;
        ImageButton.bGameCheck = false;
        ImageButton.goRankedView.GetComponent<UISprite>().depth = 8;
        ImageButton.UpgradeView.GetComponent<UISprite>().depth = 7;
        ImageButton.Button_Credit.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        ImageButton.ItemTimeUpgrade.transform.gameObject.SetActiveRecursively(false);
        transform.gameObject.SetActiveRecursively(false);
        ImageButton.UpgradeSideView.transform.gameObject.SetActiveRecursively(false);
        ImageButton.LevelLabel.transform.gameObject.SetActiveRecursively(false);
        ImageButton.UpgradeInformation.transform.gameObject.SetActiveRecursively(false);
        ImageButton.UpgradeTarget.transform.gameObject.SetActiveRecursively(false);
        ImageButton.WantCoin.transform.gameObject.SetActiveRecursively(false);
        ImageButton.ChangeUpgrade.transform.gameObject.SetActiveRecursively(false);
        ImageButton.FastStartUpgrade.transform.gameObject.SetActiveRecursively(false);
        ImageButton.ItemFastShowUpgrade.transform.gameObject.SetActiveRecursively(false);
        ImageButton.GamestartLabel.text = "준비 완료";

    }
}
