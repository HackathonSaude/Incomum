using UnityEngine;
using System.Collections;
using System;

public class Food : Collectible
{
    [SerializeField]
    int worth;

    [SerializeField]
    float speedEffect;
    [SerializeField]
    Sprite effectSprite;

    public override void Collect(Collider2D collision)
    {
        collision.GetComponent<MazeCharacter>().SetEffect(speedEffect, effectSprite);

        FindObjectOfType<MazeController>().Points += worth;

        Destroy(gameObject);
    }
}
