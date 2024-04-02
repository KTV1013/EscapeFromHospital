using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PuzzleProgressTracker : ScriptableSingleton<ProgressInfo>
{
    [SerializeField]
    ProgressInfo puzzleInfo;
    List<int> unnecessaryHints = new();
    List<int> potentialHints = new();
    #region Tracker
    public void CompleteStep(int id)
    {
        foreach (ProgressInfo.Step step in FindSteps(id))
        {
            foreach (int hintId in step.lockHints) 
            {
                if(!unnecessaryHints.Exists(id => id == hintId))
                    unnecessaryHints.Add(hintId);
            }
            foreach (int hintId in step.unlockHints) 
            {
                if(!potentialHints.Exists(id => id == hintId))
                    potentialHints.Add(hintId);
            }
        }
    }
    
    List<ProgressInfo.Step> FindSteps(int id)
    {
        return puzzleInfo.steps.FindAll(step => step.id == id);
    }

    List<ProgressInfo.Hint> FindHints(int id)
    {
        return puzzleInfo.hints.FindAll(hint => hint.id == id);
    }
    #endregion Tracker
    #region Hinter
    public string GetHint()
    {
        if (potentialHints.Count == 0)
            return "Out of hints";
        if (potentialHints.Count == 1)
            return puzzleInfo.hints[0].hint;
        int randomHintIndex = Random.Range(0, potentialHints.Count);
        return puzzleInfo.hints[potentialHints[randomHintIndex]].hint;
    }
    #endregion Hinter
}
