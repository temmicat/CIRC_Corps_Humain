using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

        public AudioSource AudioSource_Click;
        public AudioSource AudioSource_ClickImportant;

        public AudioMixer audioMixer;
        public Slider audioSlider;

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
            AudioSource_Click.Play();

            clearConfirmButton.SetActive(false);
            quitConfirmButton.SetActive(false);

            // set active ClearConfirmButton
            clearConfirmButton.SetActive(true);
        }

        public void ClearConfirmButton()
        {
            AudioSource_ClickImportant.Play();

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
            AudioSource_Click.Play();

            UpperOrgans.SetActive(true);
        }

        public void MiddleButton()
        {
            AudioSource_Click.Play();

            MiddleOrgans.SetActive(true);
        }

        public void LowerButton()
        {
            AudioSource_Click.Play();

            LowerOrgans.SetActive(true);
        }

        public void SettingsButton()
        {
            AudioSource_ClickImportant.Play();

            DeselectButton();

            // Set Active SettingsPanel
            settingsPanel.SetActive(true);
            // Set Unactive SelectionPanel
            selectionPanel.SetActive(false);
        }

        public void QuitButton()
        {
            AudioSource_ClickImportant.Play();

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
            AudioSource_Click.Play();

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
            AudioSource_ClickImportant.Play();

            DeselectButton();

            // change scene
            levelConfirmButton.SetActive(false);
            SceneManager.LoadScene(1);
        }
        #endregion SelectionPanel

        #region SettingsPanel
        public void EnglishButton()
        {
            AudioSource_Click.Play();

            // Set every texts in english ? (maybe make other scenes in english)
        }

        public void FrenchButton()
        {
            AudioSource_Click.Play();

            // Set every texts in french
        }

        public void AudioSlider()
        {
            float volume = audioSlider.value;
            audioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        }

        public void AudioButton()
        {
            AudioSource_Click.Play();

            if (audioSlider.value == 0.0001f)
            {
                audioSlider.value = 1;
                audioMixer.SetFloat("SFX", Mathf.Log10(1) * 20);
            }
            else
            {
                audioSlider.value = 0.0001f;
                audioMixer.SetFloat("SFX", Mathf.Log10(0.0001f) * 20);
            }
        }

        public void SelctionButton()
        {
            AudioSource_ClickImportant.Play();

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
            AudioSource_Click.Play();

            if (gameDataScriptable.playerAnswers.Count == gameDataScriptable.answersNumber)
            {
                gameDataScriptable.levelsCleared.Add(gameDataScriptable.levelActive);
                validateResultsButton.SetActive(false);
                backButton.SetActive(true);
                winSystem.GetResults();
            }
        }

        public void BackButton()
        {
            AudioSource_ClickImportant.Play();

            SceneManager.LoadScene(0);
        }
        #endregion GamePanel

        #region ResultPanel
        public void CloseResultPanel()
        {
            AudioSource_ClickImportant.Play();

            ResultPanel.SetActive(false);
            selectionPanel.SetActive(true);
            ClearConfirmButton();
        }

        public void SaveAsPDF()
        {
            AudioSource_Click.Play();

            return;
        }

        #endregion ResultPanel
    }
}
