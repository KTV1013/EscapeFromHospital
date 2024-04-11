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
public class ProgressTracker : MonoBehaviour
{
    static ProgressTracker instance;
    public static ProgressTracker Instance
    { 
        get 
        {
            if (instance != null)
                return instance;
            instance = new GameObject("ProgressTracker").AddComponent<ProgressTracker>();
            return Instance;
        } 
    }
    ProgressInfo puzzleInfo;
    List<int> unnecessaryHints = new();
    List<int> potentialHints = new();
    #region Tracker
    public void ResetLists()
    {
        unnecessaryHints.Clear();
        potentialHints.Clear();
    }

    private void Awake()
    {
        puzzleInfo = Resources.Load<ProgressInfo>("ScriptableObjects/PuzzleList");
        if (puzzleInfo == null) Debug.LogError("progressTracker is " + puzzleInfo, this);
    }

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
        foreach (int addId in step.addHints) 
        {
            if(!ExistInLists(addId))
                potentialHints.Add(addId);
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
    public string GetRandomHint()
    {
        if (potentialHints.Count == 0)
            return "Out of hints";
        if (potentialHints.Count == 1)
        {
            return GetAndRemovePotentialHint(0);
        }

        int randomHintIndex = Random.Range(0, potentialHints.Count);
        return GetAndRemovePotentialHint(randomHintIndex);
    }
    string GetAndRemovePotentialHint(int index)
    {
        int hintIndex = potentialHints[index];
        unnecessaryHints.Add(hintIndex);
        potentialHints.Remove(hintIndex);
        return puzzleInfo.hints[hintIndex].hint;
    }

    public List<string> GetHints() 
    {
        List<string> hints = new();
        foreach (int id in potentialHints) 
        {
            hints.Add(puzzleInfo.hints.Find(hintId => hintId.id == id).hint);
        }
        return hints;
    }
    #endregion Hinter
}
