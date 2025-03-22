using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System;
using System.Collections;
using static CorpsHumain.Core.GameData;

namespace CorpsHumain.Core
{
    public class ButtonsManager : MonoBehaviour
    {
        [Header("Buttons")]
        public GameObject clearConfirmButton;
        public GameObject quitConfirmButton;
        public GameObject levelConfirmButton;
        public GameObject levelPeauConfirmButton;
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
        public GameObject text_DragText;

        private int answersNumber = 0;
        public RectTransform content;


        [Header("Panels")]
        public GameObject settingsPanel;
        public GameObject selectionPanel;
        public GameObject ResultPanel;
        public GameObject CreditsPanel;

        [Header("Scripts")]
        public WinSystem winSystem;
        public SetLevelsCleared setLevelsCleared;
        public ShowPlayerResults showPlayerResults;



        // Need to access the Scriptable object GameData
        [SerializeField] GameData gameDataScriptable;

        void Start()
        {
            if (!gameDataScriptable.gameReloaded)
            {
                gameDataScriptable.gameReloaded = true;
                ClearConfirmButton();
            }
        }

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // Unsubscribe from the sceneLoaded event
        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        // This will be called after a new scene is loaded
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "MainMenu")
            {
                setLevelsCleared.CheckValues();

                if(LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
                {
                    organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organs";
                }
                else
                {
                    organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organes";
                }
            }
            if (scene.name == "SceneOrgan")
            {
                text_DragText.SetActive(true);
            }
                if (gameDataScriptable.levelsCleared.Count == 13)
            {
                ResultPanel.SetActive(true);
                showPlayerResults.EnterResults();
                selectionPanel.SetActive(false);
            }
            for (int i = 0; i < 13; i++) { Debug.Log("player total answers index " + i + " : " + gameDataScriptable.playerTotalAnswers[gameDataScriptable.resultsShowOrder[i]].Count); }
            // Your code to execute after the scene is loaded
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
            levelPeauConfirmButton.SetActive(false);
        }

        public void UpperButton()
        {
            AudioSource_Click.Play();
            DeselectButton();

            UpperOrgans.SetActive(true);
        }

        public void MiddleButton()
        {
            AudioSource_Click.Play();
            DeselectButton();

            MiddleOrgans.SetActive(true);
        }

        public void LowerButton()
        {
            AudioSource_Click.Play();
            DeselectButton();

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
            gameDataScriptable.gameReloaded = false;

            Application.Quit();
        }

        public void ChooseLevel(string levelStr)
        {
            AudioSource_Click.Play();

            if(levelStr == "Peau")
            {
                DeselectButton();
            }

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
                if (level == GameData.levels.Peau)
                {
                    levelPeauConfirmButton.SetActive(true);
                }
                else
                {
                    levelConfirmButton.SetActive(true);
                }

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

            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organs";
        }

        public IEnumerator English()
        {
            // Set every texts in english ? (maybe make other scenes in english)
            Debug.Log("broooo");
            if (!LocalizationSettings.InitializationOperation.IsDone)
            {
                Debug.Log("whyyyyyy");
                yield return LocalizationSettings.InitializationOperation;
            }
            else
            {
                Debug.Log("YYYYYYYYYYEAH 2");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                Debug.Log("ok 2");
            }
        }

        public IEnumerator French()
        {
            // Set every texts in english ? (maybe make other scenes in english)
            if (!LocalizationSettings.InitializationOperation.IsDone)
            {
                yield return LocalizationSettings.InitializationOperation;
            }
            else
            {
                Debug.Log("YYYYYYYYYYEAH");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                Debug.Log("ok");
            }
        }

        public void FrenchButton()
        {
            AudioSource_Click.Play();

            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            organsClearedText.text = gameDataScriptable.levelsCleared.Count.ToString() + " / 13 organes";
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

        public void CreditsButton()
        {
            AudioSource_ClickImportant.Play();

            CreditsPanel.SetActive(true);

            settingsPanel.SetActive(false);
        }

        public void BackToSettingsButton()
        {
            AudioSource_ClickImportant.Play();

            CreditsPanel.SetActive(false);

            settingsPanel.SetActive(true);
        }
        #endregion SettingsPanel

        #region GamePanel

        public void Update()
        {
            if(SceneManager.GetActiveScene().name == "SceneOrgan")
            {
                if(gameDataScriptable.playerAnswers.Count < answersNumber)
                {
                    answersNumber = gameDataScriptable.playerAnswers.Count;
                    content.sizeDelta = new Vector2(content.sizeDelta.x + 135, content.sizeDelta.y);
                }
                else if (gameDataScriptable.playerAnswers.Count > answersNumber)
                {
                    answersNumber = gameDataScriptable.playerAnswers.Count;
                    content.sizeDelta = new Vector2(content.sizeDelta.x - 135, content.sizeDelta.y);
                }

                if (gameDataScriptable.playerAnswers.Count == gameDataScriptable.answersNumber && !backButton.activeSelf)
                {
                    validateResultsButton.SetActive(true);
                }
                else
                {
                    validateResultsButton.SetActive(false);
                }

                if (gameDataScriptable.playerAnswers.Count >= 1)
                {
                    text_DragText.SetActive(false);
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
            gameDataScriptable.playerAnswers.Clear();

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

            ScreenCapture.CaptureScreenshot("Game_Results_Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png", 4);
        }

        #endregion ResultPanel
    }
}
