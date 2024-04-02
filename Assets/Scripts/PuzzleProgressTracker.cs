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
        ProgressInfo.Step step = FindStep(id);
        
        foreach (int lockId in step.lockHints) 
        {
            if(!unnecessaryHints.Exists(hintId => hintId == lockId))
                unnecessaryHints.Add(lockId);
            if(potentialHints.Exists(hintId => hintId == lockId))
                potentialHints.Remove(lockId);
        }
        foreach (int unlockId in step.unlockHints) 
        {
            if(!ExistInLists(unlockId))
                potentialHints.Add(unlockId);
        }
    }

    bool ExistInLists(int id)
    {
        bool exists = unnecessaryHints.Exists(listedId => listedId == id);
        exists = exists || potentialHints.Exists(hintId => hintId == id);
        return exists;
    }
    
    ProgressInfo.Step FindStep(int id)
    {
        return puzzleInfo.steps.Find(step => step.id == id);
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
