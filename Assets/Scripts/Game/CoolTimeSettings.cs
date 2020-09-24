using UnityEngine;
using System.Collections;

public class CoolTimeSettings : MonoBehaviour {

    float CoolTime = GameSateData.I.myData.manage.ItemTimeUpgradeLevel;
    public bool bGuardTime = false;
    public bool bMagneTime = false;
    public bool bWiderTime = false;
    public bool bScoreTime = false;
    public bool bSabotTime = false;


    GameObject ScoreCoolTime = null;
    GameObject MagneCoolTime = null;
    GameObject WiderCoolTime = null;
    GameObject GuardCoolTime = null;
    GameObject SabotCoolTime = null;

	void Start () {
        ScoreCoolTime = GameObject.Find("ScoreBalaCool");
        MagneCoolTime = GameObject.Find("MagnetCool");
        WiderCoolTime = GameObject.Find("WiderCool");
        GuardCoolTime = GameObject.Find("GuardCool");
        SabotCoolTime = GameObject.Find("SabotCool");

        ScoreCoolTime.SetActiveRecursively(false);
        MagneCoolTime.SetActiveRecursively(false);
        WiderCoolTime.SetActiveRecursively(false);
        GuardCoolTime.SetActiveRecursively(false);
        SabotCoolTime.SetActiveRecursively(false);
	}
	
	void Update () {
        if (bGuardTime == true)
            ValueGuardCoolTime();

        if (bMagneTime == true)
            ValueMagneCoolTime();
        
        if (bWiderTime == true)
            ValueWiderCoolTime();

        if (bScoreTime == true)
            ValueScoreCoolTime();

        if (bSabotTime == true)
            ValueSabotCoolTime();
	}


    void ValueGuardCoolTime()
    {
        if (GuardCoolTime.active == false)
            GuardCoolTime.SetActiveRecursively(true);

        if (GuardCoolTime.GetComponent<UIFilledSprite>().fillAmount < 0.001f)
        {
            GuardCoolTime.GetComponent<UIFilledSprite>().fillAmount = 1.0f;
            GuardCoolTime.SetActiveRecursively(false);
            bGuardTime = false;
        }
        else
            GuardCoolTime.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime / (3.0f + ( CoolTime * 0.1f ));
    }

    void ValueMagneCoolTime()
    {
        if (MagneCoolTime.active == false)
            MagneCoolTime.SetActiveRecursively(true);

        if (MagneCoolTime.GetComponent<UIFilledSprite>().fillAmount < 0.001f)
        {
            MagneCoolTime.GetComponent<UIFilledSprite>().fillAmount = 1.0f;
            MagneCoolTime.SetActiveRecursively(false);
            bMagneTime = false;
        }
        else
            MagneCoolTime.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime / (4.0f + ( CoolTime * 0.1f ));
    }

    void ValueWiderCoolTime()
    {
        if (WiderCoolTime.active == false)
            WiderCoolTime.SetActiveRecursively(true);

        if (WiderCoolTime.GetComponent<UIFilledSprite>().fillAmount < 0.001f)
        {
            WiderCoolTime.GetComponent<UIFilledSprite>().fillAmount = 1.0f;
            WiderCoolTime.SetActiveRecursively(false);
            bWiderTime = false;
        }
        else
            WiderCoolTime.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime /  ( 5.0f + ( CoolTime * 0.1f ));
    }

    void ValueScoreCoolTime()
    {
        if (ScoreCoolTime.active == false)
            ScoreCoolTime.SetActiveRecursively(true);

        if (ScoreCoolTime.GetComponent<UIFilledSprite>().fillAmount < 0.001f)
        {
            ScoreCoolTime.GetComponent<UIFilledSprite>().fillAmount = 1.0f;
            ScoreCoolTime.SetActiveRecursively(false);
            bScoreTime = false;
        }
        else
            ScoreCoolTime.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime / (5.0f + ( CoolTime * 0.1f ));
    }

    void ValueSabotCoolTime()
    {
        if (SabotCoolTime.active == false)
            SabotCoolTime.SetActiveRecursively(true);

        if (SabotCoolTime.GetComponent<UIFilledSprite>().fillAmount < 0.001f)
        {
            SabotCoolTime.GetComponent<UIFilledSprite>().fillAmount = 1.0f;
            SabotCoolTime.SetActiveRecursively(false);
            bSabotTime = false;
        }
        else
            SabotCoolTime.GetComponent<UIFilledSprite>().fillAmount -= Time.deltaTime / (3.0f + ( CoolTime * 0.1f ));
    }
}
