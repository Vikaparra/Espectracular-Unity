using UnityEngine;
using UnityEngine.Events;

public class Trash : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip successClip;
    [SerializeField] private UnityEvent onCollision;

    private void OnCollisionEnter2D()
    {
        this.onCollision.Invoke();
        source.PlayOneShot(successClip);
        GameObject.Destroy(this.gameObject);
    }

    public void SelfDestroy()
    {
        GameObject.Destroy(this.gameObject);
    }

}

