using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespectiveAnimal : MonoBehaviour
{
    private SpriteRenderer image;
    private void Awake() {
        this.image = this.GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite newSprite){
        this.image.sprite = newSprite;
    }
}
