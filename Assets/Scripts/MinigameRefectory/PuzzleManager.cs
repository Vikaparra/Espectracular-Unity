using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private List<PuzzleSlot> _slotPrefabs;
    [SerializeField] private PuzzlePiece _piece;
    [SerializeField] private Transform _slotParent,  _pieceParent;

    void Spawn(){

    }
}
