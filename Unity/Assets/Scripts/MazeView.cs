using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MazeView : MonoBehaviour
{
    MazeController mazeController;

    [Header("Message Panels")]

    [SerializeField]
    CanvasGroup successPanel;
    [SerializeField]
    CanvasGroup failPanel;
    [SerializeField]
    CanvasGroup endMessagePanel;

    [Header("UI")]

    [SerializeField]
    Text timeText;
    [SerializeField]
    Text pointsText;
    //[SerializeField]
    //GameObject livesParent;
    //[SerializeField]
    //GameObject livesPrefab;

    [SerializeField]
    float endMessageDelay = 3;

    public void Success()
    {
        EndLevel(successPanel);
    }

    public void Fail()
    {
        EndLevel(failPanel);
    }

    void EndLevel(CanvasGroup messagePanel)
    {
        messagePanel.interactable = true;
        messagePanel.blocksRaycasts = true;
        messagePanel.alpha = 1;

        Invoke("EndMessages", endMessageDelay);
    }

    void EndMessages()
    {
        endMessagePanel.interactable = true;
        endMessagePanel.blocksRaycasts = true;
        endMessagePanel.alpha = 1;
    }

    private void Start()
    {
        mazeController = GetComponent<MazeController>();
    }

    TimeSpan timespan;

    private void Update()
    {
        timespan = TimeSpan.FromSeconds(mazeController.Counter);
        timeText.text = String.Format("{0:D2}:{1:D2}", timespan.Minutes, timespan.Seconds);

        pointsText.text = mazeController.Points.ToString() + " de " + mazeController.Goal.ToString();
    }
}
