using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleSequence : Interactable
{
    [SerializeField]
    protected InteractibleSequence parent;
    [SerializeField]
    bool orderedSequence;
    [SerializeField]
    protected List<Sequence> sequences;
    public class Sequence 
    {
        public InteractibleSequence sequence;
        public bool completedSequence;
    }

    protected void Start()
    {
        foreach (var sequence in sequences) 
        {
            sequence.completedSequence = false;
        }
    }

    public void CompleteSequence(Interactable sequence)
    {
        sequences.Find(seq  => seq.sequence == sequence).completedSequence = true;
        if (SequencesComplete())
        {
            if (parent != null)
                parent.CompleteSequence(this);
            else End();
        }
    }

    protected virtual void End() { }

    public bool SequencesComplete()
    {
        return !sequences.Exists(seq => seq.completedSequence == false);
    }

    public override void EndInteraction() { }

    public override void StartInteraction()
    {
        if (parent != null)
            parent.StartInteraction();
        else End();
    }
}
