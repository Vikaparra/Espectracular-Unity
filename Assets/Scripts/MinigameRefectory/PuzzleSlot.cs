using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Transform SpriteTransform;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _successClip;
    [SerializeField] private Sprite respectiveAnimal;

    public void Success()
    {
        _source.PlayOneShot(_successClip);
    }

    public void onReset(){
        Destroy(gameObject);
    }

    public Sprite GetAnimalSprite(){
        return respectiveAnimal;
    }
}
