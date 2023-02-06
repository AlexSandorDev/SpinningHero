using System;
using System.Threading.Tasks;
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
        OpenGameOverMenu();
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
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        LoadScene(0);
    }

    void LoadScene(int sceneIndex)
    {
        Task task = transition.In();

        task.Wait(10000);

        SceneManager.LoadScene(sceneIndex);
    }
}
