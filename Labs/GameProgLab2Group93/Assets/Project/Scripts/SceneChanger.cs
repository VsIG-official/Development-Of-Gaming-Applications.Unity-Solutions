using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	private static readonly string _nextScene = "Garden";

	public static void ChangeScene()
	{
		SceneManager.LoadScene(_nextScene);
	}
}
