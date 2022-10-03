using TMPro;
using UnityEngine;

public class RugCounterText : MonoBehaviour
{
    [SerializeField]
    private string _rugCountText = "Score is: ";
    private TextMeshProUGUI _text;

	private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        RugCounter.RugCollisionAdded += UpdateRugCounter;
	}

    private void UpdateRugCounter(int rugCount)
    {
		_text.text = _rugCountText + rugCount;
	}

    private void OnDestroy()
    {
        RugCounter.RugCollisionAdded -= UpdateRugCounter;
	}
}
