using CorpsHumain.Core;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class LocalizationCardsUI : MonoBehaviour
{
    [SerializeField]
    private LocalizeStringEvent _localizationStringEvent;

    public bool isTitle;
    public DefenceCardUI thisDefenceCardUI;
    //public List<CardScriptableLocalization> scriptableList;


    /*
    public void SyncScriptable(DefenceCardData data)
    {
        for (int i = 0; i < scriptableList.Count; i++)
        {
            if (scriptableList[i].thisCardData == data)
            {
                SyncLocalization(scriptableList[i]);
                return;
            }
        }
    }
    */

    public void SyncLocalization(DefenceCardData defenceCardLocalizationScriptable)
    {
        Debug.Log("sync");
        if (isTitle) 
        { 
            _localizationStringEvent.StringReference.SetReference(defenceCardLocalizationScriptable.title_Key_Text.TableReference, defenceCardLocalizationScriptable.title_Key_Text.TableEntryReference);
            _localizationStringEvent.RefreshString();
        }
        else
        {
            _localizationStringEvent.StringReference.SetReference(defenceCardLocalizationScriptable.description_Key_Text.TableReference, defenceCardLocalizationScriptable.description_Key_Text.TableEntryReference);
            _localizationStringEvent.RefreshString();
        }
        Debug.Log("syncDone");
    }
}
