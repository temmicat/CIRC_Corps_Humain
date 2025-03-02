using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace CorpsHumain.Core
{
    public class SetLevelsCleared : MonoBehaviour
    {
        public GameData gameDataScriptable;

        [Header("Buttons")]
        public GameObject colDeLUterusButton;
        public GameObject colonRectumButton;
        public GameObject endometreButton;
        public GameObject estomacButton;
        public GameObject foieButton;
        public GameObject oesophageButton;
        public GameObject ovairesButton;
        public GameObject pancreasButton;
        public GameObject peauButton;
        public GameObject poumonsButton;
        public GameObject reinButton;
        public GameObject seinButton;
        public GameObject vessieButton;

        public GameObject colDeLUterusButton_2;
        public GameObject colonRectumButton_2;
        public GameObject endometreButton_2;
        public GameObject estomacButton_2;
        public GameObject foieButton_2;
        public GameObject oesophageButton_2;
        public GameObject ovairesButton_2;
        public GameObject pancreasButton_2;
        public GameObject peauButton_2;
        public GameObject poumonsButton_2;
        public GameObject reinButton_2;
        public GameObject seinButton_2;
        public GameObject vessieButton_2;

        public void SetButtonsActive()
        {
            colDeLUterusButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            colonRectumButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            endometreButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            estomacButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            foieButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            oesophageButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ovairesButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            pancreasButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            peauButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            poumonsButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            reinButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            seinButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            vessieButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            colDeLUterusButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            colonRectumButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            endometreButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            estomacButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            foieButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            oesophageButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ovairesButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            pancreasButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            peauButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            poumonsButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            reinButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            seinButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            vessieButton_2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        public void CheckValues()
        {
            Debug.Log("checking");
            if(gameDataScriptable.levelsCleared.Contains(GameData.levels.ColDeLUterus))
            {
                colDeLUterusButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                colDeLUterusButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.ColonRectum))
            {
                colonRectumButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                colonRectumButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Endometre))
            {
                endometreButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                endometreButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Estomac))
            {
                estomacButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                estomacButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Foie))
            {
                foieButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                foieButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Oesophage))
            {
                oesophageButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                oesophageButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Ovaires))
            {
                ovairesButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                ovairesButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Pancreas))
            {
                pancreasButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                pancreasButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Peau))
            {
                peauButton.GetComponent<Image>().color = new Color32(235, 235, 235, 190);
                peauButton_2.GetComponent<Image>().color = new Color32(235, 235, 235, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Poumon))
            {
                poumonsButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                poumonsButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Rein))
            {
                reinButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                reinButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Sein))
            {
                seinButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                seinButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
            if (gameDataScriptable.levelsCleared.Contains(GameData.levels.Vessie))
            {
                vessieButton.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
                vessieButton_2.GetComponent<Image>().color = new Color32(175, 175, 175, 190);
            }
        }
    }
}
