using UnityEngine;
using UnityEngine.Localization;

namespace CorpsHumain.Core
{
    [CreateAssetMenu(fileName = "CardScriptableLocalization", menuName = "Scriptable Objects/CardScriptableLocalization")]
    public class CardScriptableLocalization : ScriptableObject
    {

        public LocalizedString title_Key_Text;
        public LocalizedString description_Key_Text;

        public DefenceCardData thisCardData;
    }
}
