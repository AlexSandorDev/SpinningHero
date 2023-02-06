using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    Animator anim;
    [SerializeField] string outTrigger = "Out";
    [SerializeField] string inTrigger = "In";

    public TaskCompletionSource<bool> isScreenHidden = new TaskCompletionSource<bool>(false);

    void Awake()
    {
        anim = GetComponent<Animator>();
        Out();
    }

    public void Out() // animate the transition out
    {
        anim.SetTrigger(outTrigger);
    }

    public async Task In()
    {
        anim.SetTrigger(inTrigger);

        await isScreenHidden.Task;

        isScreenHidden.SetResult(false);
    }

    public void ScreenHidden()
    {
        isScreenHidden.SetResult(true);
    }

    private IEnumerator InCoroutine(int sceneIndex,float time)
    {
        yield return new WaitForSeconds(time);

        //var operation = SceneManager.LoadSceneAsync(sceneIndex);

        /*if (operation.isDone)
        {
            Out();
        }*/
    }
}
