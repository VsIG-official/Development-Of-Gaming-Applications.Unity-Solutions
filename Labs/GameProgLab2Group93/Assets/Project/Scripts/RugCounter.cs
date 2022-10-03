using System;
using UnityEngine;

public class RugCounter : MonoBehaviour
{
	[SerializeField]
	private string _rugTag = "Rug";

	public static event Action<int> RugCollisionAdded;
	private int _rugCount;
	private const int RugCountTrigger = 3;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_rugTag))
		{
			_rugCount++;
			RugCollisionAdded?.Invoke(_rugCount);
		}

		if (_rugCount == RugCountTrigger)
		{
			SceneChanger.ChangeScene();
		}
	}
}
