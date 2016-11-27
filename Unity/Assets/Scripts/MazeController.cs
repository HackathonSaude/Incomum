using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//[System.Serializable]
//public class MazeGoal
//{
//    public Collectible[] collectiblesToGet;

//    public int goal;

//    public void CheckCollectibles()
//    {
//        for (int i = 0; i < length; i++)
//        {

//        }
//    }

//    public void UnlockMessage()
//    {
//        messageToUnlock.enabled = true;
//    }

//    public Text messageToUnlock;
//}

public class MazeController : MonoBehaviour
{
    NavigationController navigation;   

    [Header("Runtime")]

    [SerializeField]
    int points;
    public int Points
    {
        get { return points; }
        set
        {
            points = Mathf.Max(0, value);
            CheckGoal();
        }
    }

    //[SerializeField]
    //MazeGoal[] mazeGoals;

    [SerializeField]
    float counter;
    public float Counter
    {
        get { return counter; }
    }

    [Header("Goal")]   

    [SerializeField]
    int pointGoal;
    public int Goal { get { return pointGoal; } }

    [SerializeField]
    float secondsToFail;
    bool counterActive = true;
    [SerializeField]
    float menuReturnDelay;
    [SerializeField]
    GameObject exitDoor;

    MazeView view;    

    public void CheckGoal()
    {
        if(points == pointGoal)
        {
            UnlockExit();
        }
    }

    void CountTime()
    {
        counter = Mathf.Max(0, counter - Time.deltaTime);

        if (counter <= 0)
        {
            Fail();
        }
    }

    public void UnlockExit()
    {
        exitDoor.SetActive(false);
    }

    //triggered by reaching the end of the level
    public void Success()
    {
        view.Success();        

        EndLevel();
    }

    public void Fail()
    {
        view.Fail();

        EndLevel();
    }

    void EndLevel()
    {
        counterActive = false;

        Invoke("ResetLevel", menuReturnDelay);
    }

    public void ResetLevel()
    {
        navigation.LoadScene("MazeScene");
    }

    private void Start()
    {
        navigation = FindObjectOfType<NavigationController>();

        counter = secondsToFail;

        counterActive = true;

        view = GetComponent<MazeView>();
    }

    private void Update()
    {        
        if(counterActive)
        {
            CountTime();
        }
    }
}
