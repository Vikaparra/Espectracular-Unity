using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private List<string> possibleReplies;
    [SerializeField] private Image questionImage;
    [SerializeField] private Button[] replyButtons;
    [SerializeField] private QuestionData questionData;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject GameFinished;

    private int currentQuestion = 0;

    private void Start()
    {
        this.questionData.questions = this.ShuffleList(this.questionData.questions);
        SetQuestion(currentQuestion);
        Right.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);
    }

    private void SetQuestion(int questionIndex)
    {
        questionImage.sprite = questionData.questions[questionIndex].questionImage;
        List<string> replyRandomOptions = GetRandomElements(possibleReplies, 4);

        foreach (Button r in replyButtons)
        {
            r.onClick.RemoveAllListeners();
        }

        for (int i = 0; i < replyButtons.Length; i++)
        {
            replyButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = replyRandomOptions[i];
            string replyText = replyRandomOptions[i];
            replyButtons[i].onClick.AddListener(() =>
            {
                CheckReply(replyText);
            });
        }
    }

    private void CheckReply(string reply)
    {
        if (reply == questionData.questions[currentQuestion].correctReply)
        {
            Right.gameObject.SetActive(true);
            foreach (Button r in replyButtons)
            {
                r.interactable = false;
            }

            StartCoroutine(Next());
        }
        else
        {
            foreach (Button r in replyButtons)
            {
                if (r.gameObject.GetComponentInChildren<TextMeshProUGUI>().text == reply)
                {
                    r.interactable = false;
                    r.gameObject.GetComponent<Image>().color = new Color(145, 145, 145);
                }
            }
        }

    }

    private IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        currentQuestion++;

        if (currentQuestion < questionData.questions.Count)
        {
            Reset();
        }
        else
        {
            GameFinished.SetActive(true);
        }
    }

    private void Reset()
    {
        Right.SetActive(false);

        foreach (Button r in replyButtons)
        {
            r.interactable = true;
            r.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        }

        SetQuestion(currentQuestion);
    }

    public void NewGame()
    {
        this.questionData.questions = this.ShuffleList(this.questionData.questions);
        this.currentQuestion = 0;

        Right.SetActive(false);
        GameFinished.SetActive(false);

        foreach (Button r in replyButtons)
        {
            r.interactable = true;
            r.gameObject.GetComponent<Image>().color = new Color(255, 255, 255);
        }

        SetQuestion(currentQuestion);
    }

    private List<string> GetRandomElements(List<string> inputList, int count)
    {
        List<string> copyOfInput = new List<string>(inputList);
        List<string> outputList = new List<string>();
        copyOfInput.Remove(questionData.questions[currentQuestion].correctReply);
        outputList.Add(questionData.questions[currentQuestion].correctReply);

        for (int i = 0; i < count - 1; i++)
        {
            int index = Random.Range(0, copyOfInput.Count);
            outputList.Add(copyOfInput[index]);
            copyOfInput.Remove(copyOfInput[index]);
        }

        outputList = ShuffleList(outputList);
        return outputList;
    }

    private List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        return list;
    }
}
