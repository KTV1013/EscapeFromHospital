using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data",menuName = "ScriptableObjects/ProgressInfo", order = 1)]
public class ProgressInfo : ScriptableObject
{
    [System.Serializable]
    public struct Hint
    {
        public string name;
        public int id;
        [TextArea]
        public string hint;
    }

    [System.Serializable]
    public struct Step
    {
        public string name;
        public int id;
        public List<int> lockHints;
        public List<int> unlockHints;
    }

    [Header("Hints that are to be given to the player")]
    [Space]
    public List<Hint> hints;
    [Header("Notable puzzle steps and related hints\n" +
        "that are rendered unnecessary upon completion")]
    [Space]
    public List<Step> steps;
}
