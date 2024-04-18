using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Transform SpriteTransform;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _successClip;

    public void Success()
    {
        _source.PlayOneShot(_successClip);
    }

}
