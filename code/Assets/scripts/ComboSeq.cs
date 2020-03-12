using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eses.CombinationLock
{
    
    // Copyright Sami S. 

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.


    // NOTE:
    // Class that store the combo and given input
    // Also has public methods to query combo state
    // and time used

    [System.Serializable]
    public class ComboSeqInt : ComboSeq<int>
    {
        public ComboSeqInt(int[] sequence, string name, bool timed = false, float timeLimit = 0) : base(sequence, name, timed, timeLimit) { }
    }


    [System.Serializable]
    public class ComboSeq<T>
    {
        public string name;

        [SerializeField] bool isTimeLimited;
        [SerializeField] float timeLimit;
        [SerializeField] float startTime;
        [SerializeField] int idx;
        [SerializeField] T[] sequence;
        T[] inputSequence;

        public ComboSeq(T[] sequence, string name, bool timed = false, float timeLimit = 0)
        {
            this.sequence = sequence;
            this.name = name;
            this.isTimeLimited = timed;
            this.timeLimit = timeLimit;
            Reset();
        }


        public void Reset()
        {
            inputSequence = new T[sequence.Length];
            idx = 0;
        }

        public bool IsNotStarted()
        {
            return idx == 0;
        }

        public void AddEntry(T entry)
        {
            if (idx == 0)
            {
                startTime = Time.time;
            }

            inputSequence[idx] = entry;
            idx++;
        }

        public bool LastEntryWasCorrect()
        {
            return inputSequence[idx - 1].Equals(sequence[idx - 1]);
        }

        public bool TimeLeft()
        {
            if (idx == 0)
            {
                return true;
            }

            return Time.time - startTime <= timeLimit;
        }

        public bool IsSequenceDone()
        {
            return idx == sequence.Length;
        }

        public bool IsSequenceCorrect()
        {
            if (isTimeLimited && !TimeLeft())
            {
                return false;
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i].Equals(inputSequence[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }

    }

}