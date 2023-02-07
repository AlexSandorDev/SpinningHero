using UnityEngine.SceneManagement;

public class SceneLoader
{
	public static async void LoadScene(int sceneIndex,Transition transition)
	{
		await transition.In();

		SceneManager.LoadScene(sceneIndex);
	}
}
