using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CorpsHumain.Core
{
    public class ButtonsManager : MonoBehaviour
    {
        [Header("Buttons")]
        public GameObject clearConfirmButton;
        public GameObject quitConfirmButton;
        public GameObject levelConfirmButton;
        public GameObject validateResultsButton;
        public GameObject backButton;

        public GameObject UpperOrgans;
        public GameObject MiddleOrgans;
        public GameObject LowerOrgans;

        public TextMeshProUGUI organsClearedText;

        [Header("Panels")]
        public GameObject settingsPanel;
        public GameObject selectionPanel;
        public GameObject ResultPanel;

        [Header("Scripts")]
        public WinSystem winSystem;
        public SetLevelsCleared setLevelsCleared;
        public ShowPlayerResults showPlayerResults;


        // Need to access the Scriptable object GameData
        [SerializeField] GameData gameDataScriptable;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                setLevelsCleared.CheckValues();
                organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organes";
            }
            if (gameDataScriptable.levelsCleared.Count == 13)
            {
                ResultPanel.SetActive(true);
                showPlayerResults.EnterResults();
                selectionPanel.SetActive(false);
            }
            for (int i = 0; i < 13; i++) { Debug.Log("player total answers index " + i + " : " + gameDataScriptable.playerTotalAnswers[gameDataScriptable.resultsShowOrder[i]].Count); }
        }

        #region SelectionPanel
        public void ClearButton()
        {
            clearConfirmButton.SetActive(false);
            quitConfirmButton.SetActive(false);

            // set active ClearConfirmButton
            clearConfirmButton.SetActive(true);
        }

        public void ClearConfirmButton()
        {
            // Reset GameData
            gameDataScriptable.levelsCleared.Clear();
            gameDataScriptable.playerAnswers.Clear();

            setLevelsCleared.SetButtonsActive();

            clearConfirmButton.SetActive(false);

            organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organes";
        }

        public void DeselectButton()
        {
            UpperOrgans.SetActive(false);
            MiddleOrgans.SetActive(false);
            LowerOrgans.SetActive(false);
            clearConfirmButton.SetActive(false);
            quitConfirmButton.SetActive(false);
            levelConfirmButton.SetActive(false);
        }

        public void UpperButton()
        {
            UpperOrgans.SetActive(true);
        }

        public void MiddleButton()
        {
            MiddleOrgans.SetActive(true);
        }

        public void LowerButton()
        {
            LowerOrgans.SetActive(true);
        }

        public void SettingsButton()
        {
            DeselectButton();

            // Set Active SettingsPanel
            settingsPanel.SetActive(true);
            // Set Unactive SelectionPanel
            selectionPanel.SetActive(false);
        }

        public void QuitButton()
        {
            clearConfirmButton.SetActive(false);
            quitConfirmButton.SetActive(false);

            // SetActive QuitConfirmButton
            quitConfirmButton.SetActive(true);
        }

        public void QuitConfirmButton()
        {

            // Quit game
            quitConfirmButton.SetActive(false);
            Application.Quit();
        }

        public void ChooseLevel(string levelStr)
        {
            if (System.Enum.TryParse(levelStr, out GameData.levels level))
            {
                ChooseOrgan(level);
            }
        }

        private void ChooseOrgan(GameData.levels level)
        {
            // Select one organ from GameData.levelsList
            if (!gameDataScriptable.levelsCleared.Contains(level))
            {
                gameDataScriptable.levelActive = level;
                levelConfirmButton.SetActive(true);
                Debug.Log(level);
                Debug.Log(gameDataScriptable.levelActive);
            }
            else { }
        }

        public void LevelConfirmButton()
        {
            DeselectButton();

            // change scene
            levelConfirmButton.SetActive(false);
            SceneManager.LoadScene(1);
        }
        #endregion SelectionPanel

        #region SettingsPanel
        public void EnglishButton()
        {
            // Set every texts in english ? (maybe make other scenes in english)
        }

        public void FrenchButton()
        {
            // Set every texts in french
        }

        public void SelctionButton()
        {
            // Set Active selectionPanel
            selectionPanel.SetActive(true);
            // Set UnActive settingsPanel
            settingsPanel.SetActive(false);
        }
        #endregion SettingsPanel

        #region GamePanel

        public void Update()
        {
            if(SceneManager.GetActiveScene().name == "SceneOrgan")
            {
                if(gameDataScriptable.playerAnswers.Count == gameDataScriptable.answersNumber)
                {
                    validateResultsButton.SetActive(true);
                }
                else
                {
                    validateResultsButton.SetActive(false);
                }
            }    
        }

        public void ValidateResultsButton()
        {
            if(gameDataScriptable.playerAnswers.Count == gameDataScriptable.answersNumber)
            {
                gameDataScriptable.levelsCleared.Add(gameDataScriptable.levelActive);
                validateResultsButton.SetActive(false);
                backButton.SetActive(true);
                winSystem.GetResults();
            }
        }

        public void BackButton()
        {
            SceneManager.LoadScene(0);
        }
        #endregion GamePanel

        #region ResultPanel
        public void CloseResultPanel()
        {
            ResultPanel.SetActive(false);
            selectionPanel.SetActive(true);
            ClearConfirmButton();
        }

        public void SaveAsPDF()
        {
            return;
        }

        #endregion ResultPanel
    }
}
