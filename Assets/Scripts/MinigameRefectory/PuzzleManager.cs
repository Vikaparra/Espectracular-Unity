using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piecePrefab;
    [SerializeField] private Transform _slotParent, _pieceParent;
    [SerializeField] private RespectiveAnimal respectiveAnimal;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject GameFinished;

    private readonly List<PuzzlePiece> _instantiatedItems = new List<PuzzlePiece>();
    private PuzzleSlot _instantiatedItemSlot;
    private int _currentQuestion = 0;

    void Start()
    {
        Spawn();
        Right.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);
    }
    void Spawn()
    {
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).ToList();
        var correctItemIndex = Random.Range(0, randomSet.Count);
        _instantiatedItemSlot = Instantiate(randomSet[correctItemIndex], _slotParent.GetChild(0).position, Quaternion.identity);
        respectiveAnimal.SetSprite(_instantiatedItemSlot.GetAnimalSprite());

        for (int i = 0; i < randomSet.Count; i++)
        {
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity);
            spawnedPiece.Init(randomSet[i], _instantiatedItemSlot);
            spawnedPiece.onCorrectAnswer.AddListener(OnCorrectAnswer);
            _instantiatedItems.Add(spawnedPiece);
        }

    }

    public void ResetGame()
    {
        _instantiatedItemSlot.onReset();
        foreach (var item in _instantiatedItems)
        {
            item.onReset();
        }

        _instantiatedItems.Clear();
        Right.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);

        Spawn();
    }

    private IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        _currentQuestion++;
        Debug.Log("Coroutine");

        if (_currentQuestion < 10)
        {
            ResetGame();
        }
        else
        {
            GameFinished.SetActive(true);
            _currentQuestion = 0;
        }
    }

    public void OnCorrectAnswer()
    {
        Debug.Log("OnCorrectAnswer");
        Right.gameObject.SetActive(true);
        StartCoroutine(Next());
    }
}
