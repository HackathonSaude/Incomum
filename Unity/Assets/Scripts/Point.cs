using UnityEngine;
using System.Collections;
using System;

public class Point : Collectible
{
    [SerializeField]
    int worth;

    public override void Collect(Collider2D collision)
    {
        FindObjectOfType<MazeController>().Points += worth;

        Destroy(gameObject);
    }
}
