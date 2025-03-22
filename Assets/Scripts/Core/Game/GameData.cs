using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace CorpsHumain.Core
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
    public class GameData : ScriptableObject
    {
        public enum levels
        {
            Peau, Oesophage, Poumon, Sein, 
            Estomac, Foie, Rein, 
            Pancreas, ColonRectum, Vessie, 
            Endometre, ColDeLUterus, Ovaires
        }

        public levels levelActive;

        // list levelsCleared
        public List<levels> levelsCleared;

        // list organ : answers
        public List<CardType> playerAnswers;

        public int answersNumber;

        public bool gameReloaded = false;

        public List<DefenceCard> answers = new List<DefenceCard>();


        // Game answers
        public Dictionary<levels, List<DefenceCard>> playerTotalAnswers = new Dictionary<levels, List<DefenceCard>>()
        {
            {levels.Rein, new List<DefenceCard>()},
            {levels.Ovaires, new List<DefenceCard>() },
            {levels.Sein, new List<DefenceCard>() },
            {levels.Pancreas, new List<DefenceCard>() },
            {levels.ColDeLUterus, new List<DefenceCard>() },
            {levels.ColonRectum, new List<DefenceCard>() },
            {levels.Endometre, new List<DefenceCard>() },
            {levels.Estomac, new List<DefenceCard>() },
            {levels.Foie, new List<DefenceCard>() },
            {levels.Oesophage, new List<DefenceCard>() },
            {levels.Poumon, new List<DefenceCard>() },
            {levels.Vessie, new List<DefenceCard>() },
        };

        public List<levels> resultsShowOrder;
    }
}
