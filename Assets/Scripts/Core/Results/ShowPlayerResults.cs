using UnityEngine;

namespace CorpsHumain.Core
{
    public class ShowPlayerResults : MonoBehaviour
    {
        public GameObject verticalLayoutAnswers;
        public GameData gameDataScriptable;

        public DefenceCardUI prefab;

        public int numberOfOrgans;

        public void EnterResults()
        {
            for(int indexOrgans = 0; indexOrgans < numberOfOrgans; indexOrgans++)
            {
                Debug.Log("doing");
                // set CurrentOrgan as organ(indexOrgans)

                for (int indexChild_VerticalLayout = 0; indexChild_VerticalLayout < verticalLayoutAnswers.transform.childCount; indexChild_VerticalLayout++)
                {
                    GameObject HorizontalLayout = verticalLayoutAnswers.transform.GetChild(indexChild_VerticalLayout).gameObject;

                    for(int indexChild_HorizontalLayout = 0; indexChild_HorizontalLayout < HorizontalLayout.transform.childCount; indexChild_HorizontalLayout++)
                    {
                        GameObject Answer = HorizontalLayout.transform.GetChild(indexChild_HorizontalLayout).gameObject;

                        // now the part we will change datas
                        GameObject Organ = Answer.transform.GetChild(0).gameObject;
                        // change image of Organ

                        GameObject PlayerAnswers = Answer.transform.GetChild(2).gameObject;
                        GameObject CorrectAnswers = Answer.transform.GetChild(4).gameObject;

                        Debug.Log(gameDataScriptable.playerTotalAnswers[gameDataScriptable.resultsShowOrder[indexOrgans]].Count);
                        for (int y = 0; y < gameDataScriptable.playerTotalAnswers[gameDataScriptable.resultsShowOrder[indexOrgans]].Count; y++)
                        {
                            Debug.Log("condition entered");

                            PlayerAnswers.transform.GetChild(y).gameObject.GetComponent<DefenceCardUI>().SetData(gameDataScriptable.playerTotalAnswers[gameDataScriptable.resultsShowOrder[indexOrgans]][y]);
                            Debug.Log("it should work");
                        }
                        indexOrgans++;
                    }
                }
            }
        }
    }
}
