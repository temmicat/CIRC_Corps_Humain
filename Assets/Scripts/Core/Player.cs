using LTX.Singletons;
using UnityEngine;

namespace CorpsHumain.Core
{
    [DefaultExecutionOrder(-100)]
    public class Player : MonoSingleton<Player>
    {

        // This Script Creates the DefenceCardHand, based on the Cards located under Resources -> Cards
        public GameObject organGameObject;

        public DefenceCardHand cardHand;
        public DefenceCardHand organHand;
        public DefenceCardHand organHandAlreadyGiven;

        [SerializeField]
        public DefenceCardHandUI handUI;
        [SerializeField]
        public DefenceCardHandUI organhandUI;
        [SerializeField]
        public DefenceCardHandUI organHandAlreadyGivenUI;

        private DefenceCardData[] dataList;

        private bool alreadyPutCards;

        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Player");

            alreadyPutCards = false;

            cardHand = new DefenceCardHand(12);
            organHand = new DefenceCardHand(12);
            organHandAlreadyGiven = new DefenceCardHand(12);
            handUI.Bind(cardHand);
            organhandUI.Bind(organHand);
            organHandAlreadyGivenUI.Bind(organHandAlreadyGiven);


            DefenceCardData[] data = Resources.LoadAll<DefenceCardData>("Cards");
            dataList = data;
            // Instantiate Organe where thisOrgane == GameData.levelActive

            for (int i = 0; i < data.Length; i++)
            {
                DefenceCard card = new DefenceCard(data[i]);
                card.isPlayerCard = true;

                if (i < 2)
                {
                    cardHand.TryAddCard(card);
                }
            }
        }

        private void Update()
        {
            if(organGameObject.GetComponent<OrganeUI>().organeDataScriptable != null && !alreadyPutCards)
            {
                for (int i = 0; i < dataList.Length; i++)
                {
                    DefenceCard card = new DefenceCard(dataList[i]);
                    Debug.Log(organGameObject.GetComponent<OrganeUI>().organeDataScriptable.thisOrganOtherAnswers.Count);

                    if (organGameObject.GetComponent<OrganeUI>().organeDataScriptable.thisOrganOtherAnswers.Contains(dataList[i].thisCard))
                    {
                        Debug.Log("ok?");
                        organHandAlreadyGiven.TryAddCard(card);
                    }
                }
                alreadyPutCards = true;
            }
        }


        public void DropCardOnOrgan(DefenceCard card)
        {
            cardHand.TryRemoveCard(card);
            organHand.TryAddCard(card);
            card.isPlayerCard = false;
        }

        public void RemoveCardOfOrgan(DefenceCard card)
        {
            organHand.TryRemoveCard(card);
            cardHand.TryAddCard(card);
            card.isPlayerCard = true;
        }
    }
}
