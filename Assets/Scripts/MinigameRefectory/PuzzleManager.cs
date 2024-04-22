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

    private readonly List<PuzzlePiece> _instantiatedItems = new List<PuzzlePiece>();
    private PuzzleSlot _instantiatedItemSlot;

    void Start()
    {
        Spawn();
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
        Spawn();
    }
}
