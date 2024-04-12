using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintPrinter : MonoBehaviour
{
    [SerializeField]
    GameObject hint;
    ProgressTracker progressTracker;

    int numberOfHints = 0;
    private void Start()
    {
        progressTracker = ProgressTracker.Instance;
        progressTracker.ResetLists();
        progressTracker.CompleteStep(0); //Start Step
    }

    [ContextMenu("Print it")]
    public void Print()
    {
        numberOfHints++;
        GameObject newHint = Instantiate(hint, transform);
        newHint.transform.GetChild(0).GetChild(0).TryGetComponent(out TextMeshProUGUI textMPGUI);
        if (progressTracker != null)
            textMPGUI.text = progressTracker.GetRandomHint();
        else textMPGUI.text = "Game is not in playmode\n or progress tracker is null";
        newHint.name = "Hint " + numberOfHints;
    }
}