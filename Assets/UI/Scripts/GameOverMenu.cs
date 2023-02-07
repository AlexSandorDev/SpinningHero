using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Animator canvasAnim;
    [SerializeField] Transition transition;

    void Start()
    {
        GameManager.playerTransform.GetComponent<PlayerHealth>().OnPlayerDeath += OpenGameOverMenuOnEvent;
        menu.SetActive(false);
    }

    void OpenGameOverMenuOnEvent(object sender, EventArgs args)
    {
        OpenGameOverMenu();
    }

    void OpenGameOverMenu()
    {
        canvasAnim.SetBool("GameOver", true);
        menu.SetActive(true);
    }

    public void Restart()
    {
        SceneLoader.LoadScene(SceneManager.GetActiveScene().buildIndex,transition);
    }

    public void Home()
    {
        SceneLoader.LoadScene(0,transition);
    }
}
