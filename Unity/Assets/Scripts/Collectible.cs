using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
    public abstract void Collect(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Collect(collision);
        }
    }
}
