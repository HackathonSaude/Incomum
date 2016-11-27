using UnityEngine;
using System.Collections;

public class MazeEndTrigger : MonoBehaviour
{
    MazeController maze;

    void Start()
    {
        maze = FindObjectOfType<MazeController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        maze.Success();
    }
}
