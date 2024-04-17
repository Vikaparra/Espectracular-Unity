using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    private Vector2 _offset, _originalPosition;
    private bool _dragging;

    void Awake(){
        _originalPosition = transform.position;
    }

    void Update()
    {
        if(!_dragging) return;

        var mousePosition = GetMousePosition();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown() {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        _offset = GetMousePosition() - (Vector2)transform.position;
    }

    private void OnMouseUp(){
        transform.position = _originalPosition;
        _dragging = false;
        _source.PlayOneShot(_dropClip);
    }

    Vector2 GetMousePosition(){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
