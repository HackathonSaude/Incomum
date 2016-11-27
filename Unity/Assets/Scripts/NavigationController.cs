using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public readonly string MenuScene = "MenuScene";

    CanvasGroup currentScreen;

    public void ShowScreen(CanvasGroup screen)
    {
        ToggleScreen(true, screen);
    }

    public void HideScreen(CanvasGroup screen)
    {
        ToggleScreen(false, screen);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void ToggleScreen(bool show, CanvasGroup screen)
    {
        screen.alpha = show ? 1 : 0;
        screen.blocksRaycasts = show;
        screen.interactable = show;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
