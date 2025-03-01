using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace CorpsHumain.Core
{
    public class WinSystem : MonoBehaviour
    {
        public GameData gameDataScriptable;
        public OrganeUI organUI;
        public GameObject organHand;

        // private List<DefenceCard> answers = new List<DefenceCard>();

        public void GetResults()
        {
            bool thisCardIsGoodAnswer = false;
            // Compare results to organ data 
            Debug.Log(organUI.organeDataScriptable.numberOfAnswers);
            for (int answerNumber = 0; answerNumber < organUI.organeDataScriptable.numberOfAnswers; answerNumber++) 
            {
                for (int cardNumber = 0; cardNumber < organUI.organeDataScriptable.numberOfAnswers; cardNumber++)
                {
                    if (gameDataScriptable.playerAnswers[answerNumber] == organUI.organeDataScriptable.thisOrganAnswers[cardNumber])
                    {
                        // Set This card to valid
                        thisCardIsGoodAnswer |= true;
                    }
                    //
                }
                ResultUI(answerNumber, thisCardIsGoodAnswer);
                thisCardIsGoodAnswer = false ;
            }
            gameDataScriptable.playerAnswers.Clear();
            Debug.Log("Game datas answer number : " + gameDataScriptable.answers.Count);
            List<DefenceCard> theList = new List<DefenceCard>();
            for (int i = 0; i < gameDataScriptable.answers.Count; i++)
            {
                theList.Add(gameDataScriptable.answers[i]);
            }
            Debug.Log("theList answer number : " + gameDataScriptable.answers.Count);
            gameDataScriptable.playerTotalAnswers[organUI.organeDataScriptable.thisOrgane] = theList;
            Debug.Log("number of answers : " + gameDataScriptable.playerTotalAnswers[organUI.organeDataScriptable.thisOrgane].Count); 
            gameDataScriptable.answers.Clear();
            Debug.Log("number of answers : " + gameDataScriptable.playerTotalAnswers[organUI.organeDataScriptable.thisOrgane].Count); 
        }

        private void ResultUI(int i, bool thisCardIsGoodAnswer)
        {
            GameObject card = organHand.transform.GetChild(i).gameObject;
            Image cardImage = card.transform.GetChild(0).gameObject.GetComponent<Image>();
            if (thisCardIsGoodAnswer)
            {
                Debug.Log("True");
                cardImage.color = Color.green;
            }
            else
            {
                cardImage.color = Color.red;
                Debug.Log("Falseeee");
            }

            // answers.Add(card.GetComponent<DefenceCard>());
        }
    }
}
