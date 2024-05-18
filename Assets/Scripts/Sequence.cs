using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sequence : MonoBehaviour
{
    [SerializeField]
    bool orderedSequence;
    [SerializeField]
    protected List<StepInfo> stepInfos;
    [SerializeField]
    protected int progressStepId;
    [SerializeField]
    protected UnityEvent onCompletion;

    protected Sequence parent;
    [Serializable]
    public class StepInfo 
    {
        public Sequence step;
        public bool completedSequence;
    }
    int StepIndex = 0;
    protected void Start()
    {
        foreach (var sequence in stepInfos) 
        {
            sequence.completedSequence = false;
            sequence.step.parent = this;
        }
    }

    public void CompleteStep(Sequence step)
    {
        if (SequencesComplete()) return;
        int index = stepInfos.FindIndex(stepInfo  => stepInfo.step == step);
        if (index == -1) return;
        int lastIndex = stepInfos.FindLastIndex(stepInfo => stepInfo.step == step);
        
        if (lastIndex != index)
        {
            bool ordered = true;
            for (int i = index; i <= lastIndex; i++) 
            {
                bool stepDone = stepInfos[i].completedSequence;
                if (stepInfos[i].step == step)
                {
                    bool unOrdered =  !ordered || i != StepIndex;
                    
                    if (!stepDone)
                    {
                        if (orderedSequence && unOrdered) 
                        {
                            ResetProgress();
                            return;
                        }
                        index = i;
                        break;
                    }
                }
                ordered = ordered && stepDone;
            }
        }
        else if (orderedSequence && index != StepIndex)
        {
            ResetProgress();
            return;
        }

        
        stepInfos[index].completedSequence = true;
        StepIndex++;
        if (SequencesComplete())
        {
            CompleteSequence();
        }
    }
    public void CompleteSequence()
    {
        if (parent != null)
            parent.CompleteStep(this);
        End();
    }

    void ResetProgress()
    {
        Debug.Log("Reset");
        StepIndex = 0;
        foreach(var stepInfo in stepInfos)
        {
            stepInfo.completedSequence = false;
        }
    }

    protected virtual void End() 
    {
        ProgressTracker.instance.CompleteStep(progressStepId);
        onCompletion.Invoke();
        enabled = false;
    }

    public bool SequencesComplete()
    {
        return !stepInfos.Exists(stepInfo => stepInfo.completedSequence == false);
    }
}
