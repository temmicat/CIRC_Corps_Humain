using UnityEngine;

namespace CorpsHumain.Core
{
    public class EmplacementCartes : MonoBehaviour
    {
        public GameObject cardEmplacmentPrefab;
        public GameObject organHand;
        public GameData gameDataScriptable;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            for (int i = 0; i < gameDataScriptable.answersNumber; i++)
            {
                Instantiate(cardEmplacmentPrefab, organHand.transform);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
