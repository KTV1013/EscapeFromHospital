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
        progressTracker = ProgressTracker.instance;
        progressTracker.ResetLists();
        progressTracker.CompleteStep(0);
    }

    [ContextMenu("Print it")]
    public void Print()
    {
        numberOfHints++;
        GameObject newHint = Instantiate(hint);
        newHint.transform.GetChild(0).GetChild(0).TryGetComponent(out TextMeshProUGUI textMPGUI);
        if (progressTracker != null)
            textMPGUI.text = progressTracker.GetRandomHint();
        else textMPGUI.text = "Game is not in playmode\n or progress tracker is null";
        newHint.name = "Hint " + numberOfHints;
    }
}
