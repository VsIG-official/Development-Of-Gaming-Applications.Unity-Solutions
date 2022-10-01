using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RugCounter : MonoBehaviour
{
	[SerializeField]
	private string _rugTag = "Rug";

	public static event Action<int> RugCollisionAdded;
	private int _rugCount;
	private const int RugCountTrigger = 4;
	private const string NextScene = "Garden";

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_rugTag))
		{
			_rugCount++;
			RugCollisionAdded?.Invoke(_rugCount);
		}

		if (_rugCount == RugCountTrigger)
		{
			SceneManager.LoadScene(NextScene);
		}
	}
}
