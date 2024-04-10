using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField]
    bool orderedSequence;
    [SerializeField]
    protected List<Step> sequences;
    
    protected Sequence parent;
    public class Step 
    {
        public Sequence step;
        public bool completedSequence;
    }

    protected void Start()
    {
        foreach (var sequence in sequences) 
        {
            sequence.completedSequence = false;
            sequence.step.parent = this;
        }
    }

    public void CompleteStep(Sequence sequence)
    {
        int index = sequences.FindIndex(seq  => seq.step == sequence);
        if (orderedSequence) 
        {
            int failIndex = sequences.FindIndex(seq => seq.completedSequence == false);
            if (failIndex < index)
            {
                ResetProgress();
                return;
            }
        }
        sequences[index].completedSequence = true;
        
        if (SequencesComplete())
        {
            CompleteSequence();
        }
    }
    void CompleteSequence()
    {
        if (parent != null)
            parent.CompleteStep(this);
        else End();
    }

    void ResetProgress()
    {
        foreach(var sequence in sequences)
        {
            sequence.completedSequence = false;
        }
    }

    protected virtual void End() 
    {
        
    }

    public bool SequencesComplete()
    {
        return !sequences.Exists(seq => seq.completedSequence == false);
    }
}
