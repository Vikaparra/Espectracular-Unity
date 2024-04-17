using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New QuestionData", menuName = "QuestionData")]
public class QuestionData : ScriptableObject
{
    [System.Serializable]
    public struct Question {
        public Sprite questionImage;
        public string correctReply;
    }


    [SerializeField] public List<Question> questions;
}
