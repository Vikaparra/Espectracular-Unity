using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _pickUpClip, _dropClip;
    private Vector2 _offset, _originalPosition;
    private bool _dragging, _placed;
    private PuzzleSlot _slot;
    private PuzzleSlot _correctItemSlot;

    public void Init(PuzzleSlot slot, PuzzleSlot correctItemSlot)
    {
        transform.localScale = slot.transform.localScale;
        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
        _correctItemSlot = correctItemSlot;
    }

    void Awake()
    {
        _originalPosition = transform.position;
    }

    void Update()
    {
        if (_placed) return;
        if (!_dragging) return;

        var mousePosition = GetMousePosition();

        transform.position = mousePosition - _offset;
    }

    private void OnMouseDown()
    {
        _dragging = true;
        _source.PlayOneShot(_pickUpClip);
        _offset = GetMousePosition() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if ((Vector2.Distance(transform.position, _correctItemSlot.transform.position) < 3) && (_slot.Renderer.sprite == _correctItemSlot.Renderer.sprite))
        {
            transform.position = _correctItemSlot.transform.position;
            _correctItemSlot.Success();
            _placed = true;
        }
        else
        {
            transform.position = _originalPosition;
            _source.PlayOneShot(_dropClip);
            _dragging = false;
        }
    }

    Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void onReset(){
        Destroy(gameObject);
    }
}
