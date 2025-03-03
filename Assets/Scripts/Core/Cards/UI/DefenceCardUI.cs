
using log4net.Util;
using PlasticPipe.PlasticProtocol.Messages;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CorpsHumain.Core
{
    public class DefenceCardUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {

        // This script handles the conversion between datas in DefenceCardData and the UI

        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;

        [SerializeField]
        private Image icon;

        public GameData gameDataScriptable;


        [SerializeField]
        public DefenceCardData thisDefenceCardData;

        public DefenceCard thisDefenceCard;

        public event Action<DefenceCardData> dataSet;

        public LocalizationCardsUI localizationCardsTitle;
        public LocalizationCardsUI localizationCardsDescription;

        public void Start()
        {
            if (thisDefenceCardData != null) 
            {
                thisDefenceCard = new DefenceCard(thisDefenceCardData);
                thisDefenceCard.Data = thisDefenceCardData;
                SetData(thisDefenceCard);
            }
        }

        public void SetData(DefenceCard card)
        {
            title.text = card.Data.Title;
            description.text = card.Data.Description;
            icon.sprite = card.Data.Icon;

            thisDefenceCard = card;

            localizationCardsTitle.SyncLocalization(thisDefenceCard.Data);
            localizationCardsDescription.SyncLocalization(thisDefenceCard.Data);
        }

        private Vector3 lastPosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            lastPosition = transform.position;
            //playerHandScript.TryRemoveCard(thisDefenceCard);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
            //TODO sortir de la main pour pouvoir bouger librement
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (thisDefenceCard.isPlayerCard)
            {
                List<RaycastResult> results = new List<RaycastResult>();

                EventSystem.current.RaycastAll(eventData, results);

                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.TryGetComponent(out OrganeUI organeUI) && gameDataScriptable.playerAnswers.Count < gameDataScriptable.answersNumber)
                    {

                        //TODO deposer carte
                        Player.Instance.DropCardOnOrgan(thisDefenceCard);

                        //ADD card to GameData
                        gameDataScriptable.playerAnswers.Add(thisDefenceCard.Data.thisCard);
                        gameDataScriptable.answers.Add(thisDefenceCard);

                        Debug.Log("Yay");
                        // gameDataScriptable.gameAnswers[gameDataScriptable.levelActive][gameDataScriptable.playerAnswers.Count] = this.gameObject;
                        Debug.Log("ça marche ?");


                        Destroy(this.gameObject);

                        return;
                    }
                }

                transform.position = lastPosition;
            }
            else
            {
                List<RaycastResult> results = new List<RaycastResult>();

                EventSystem.current.RaycastAll(eventData, results);

                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.TryGetComponent(out OrganeUI organeUI))
                    {
                        transform.position = lastPosition;
                        return;
                    }
                    else
                    {

                        //TODO deposer carte
                        Player.Instance.RemoveCardOfOrgan(thisDefenceCard);
                        Destroy(this.gameObject);

                        //REMOVE card from WinSystem
                        gameDataScriptable.playerAnswers.Remove(thisDefenceCard.Data.thisCard);
                        gameDataScriptable.answers.Remove(thisDefenceCard);

                        return;
                    }
                }
            }
            //TODO Si rien na ete touché en deposant, retourner dans la main
        }
    }
}
