using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CorpsHumain.Core
{
    public class UpdateCardNumber : MonoBehaviour
    {
        public TextMeshProUGUI cardDeposedIndicator;
        public GameData gameDataScriptable;
        public OrganeUI organeUI;

        // Update is called once per frame
        void Update()
        {
            cardDeposedIndicator.text = gameDataScriptable.playerAnswers.Count.ToString() + " / " + organeUI.organeDataScriptable.numberOfAnswers.ToString();
        }
    }
}
