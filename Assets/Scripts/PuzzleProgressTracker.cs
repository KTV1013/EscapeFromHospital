using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// <para> 
/// Keeps track of how much progress the player has made towards completing all puzzles 
/// </para>
/// <para> 
/// It checks what hints become available as well as which become unnecessary
/// </para>
/// </summary>
public class PuzzleProgressTracker : ScriptableSingleton<PuzzleProgressTracker>
{
    [SerializeField]
    ProgressInfo puzzleInfo;
    List<int> unnecessaryHints = new();
    List<int> potentialHints = new();
    #region Tracker

    public void CompleteStep(int id)
    {
        ProgressInfo.Step step = FindStep(id);
        foreach (ProgressInfo.Hint lockId in step.lockHints) 
        {
            if(!unnecessaryHints.Exists(hintId => hintId == lockId.id))
                unnecessaryHints.Add(lockId.id);
            if(potentialHints.Exists(hintId => hintId == lockId.id))
                potentialHints.Remove(lockId.id);
        }
        foreach (ProgressInfo.Hint addId in step.addHints) 
        {
            if(!ExistInLists(addId.id))
                potentialHints.Add(addId.id);
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
        if (puzzleInfo == null) 
            puzzleInfo = Resources.Load<ProgressInfo>("ScriptableObjects/PuzzleList");
        return puzzleInfo.steps.Find(step => step.id == id);
    }
    #endregion Tracker
    #region Hinter
    public string GetRandomHint()
    {
        if (potentialHints.Count == 0)
            return "Out of hints";
        if (puzzleInfo == null)
            puzzleInfo = Resources.Load<ProgressInfo>("ScriptableObjects/PuzzleList");
        if (potentialHints.Count == 1)
            return puzzleInfo.hints[0].hint;

        int randomHintIndex = Random.Range(0, potentialHints.Count);
        return puzzleInfo.hints[potentialHints[randomHintIndex]].hint;
    }

    public List<string> GetHints() 
    {
        List<string> hints = new();
        if (puzzleInfo == null)
            puzzleInfo = Resources.Load<ProgressInfo>("ScriptableObjects/PuzzleList");
        foreach (int id in potentialHints) 
        {
            hints.Add(puzzleInfo.hints.Find(hintId => hintId.id == id).hint);
        }
        return hints;
    }

    public void ResetLists()
    {
        unnecessaryHints.Clear();
        potentialHints.Clear();
    }
    #endregion Hinter
}
