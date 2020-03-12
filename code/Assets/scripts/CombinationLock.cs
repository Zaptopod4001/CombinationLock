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
    // Demo class, shows how 
    // ComboSeq class can be used

    public class CombinationLock : MonoBehaviour
    {

        public enum State
        {
            None,
            Locked,
            InputStarted,
            Busy,
            Opened
        }

        [Header("Assign")]
        [SerializeField] Image lockStateImage;
        [SerializeField] Text lockStateText;

        [Header("Lock settings")]
        [SerializeField] bool hasTimeLimit = false;
        [SerializeField] float timeLimit = 8f;
        [SerializeField] int[] sequence = { 1, 5, 9 };
        [SerializeField] bool instantFail = false;

        [Header("Lock state")]
        [SerializeField] State state;
        [SerializeField] ComboSeqInt comboLock;


        // Init

        void Start()
        {
            comboLock = new ComboSeqInt(sequence, "lock", hasTimeLimit, timeLimit);
            ResetState();
        }


        // Main 

        public void Update()
        {
            if (state != State.InputStarted)
            {
                return;
            }

            if (hasTimeLimit && !comboLock.TimeLeft())
            {
                state = State.Busy;
                StartCoroutine(ResetSeq("TIME OUT"));
            }
        }


        // Call from UI

        public void EnterDoorCode(int number)
        {
            if (comboLock.IsNotStarted())
            {
                state = State.InputStarted;
            }

            if (state != State.InputStarted)
            {
                return;
            }

            comboLock.AddEntry(number);
            lockStateText.text = "ENTER SEQUENCE";


            if (instantFail && !comboLock.LastEntryWasCorrect())
            {
                state = State.Busy;
                StartCoroutine(ResetSeq("INCORRECT"));
                return;
            }

            if (comboLock.IsSequenceDone())
            {
                if (comboLock.IsSequenceCorrect())
                {
                    state = State.Busy;
                    StartCoroutine(OpenSeq());
                }
                else
                {
                    state = State.Busy;
                    StartCoroutine(ResetSeq("INCORRECT"));
                }
            }
            else
            {
                AudioManager.instance.PlayCorrect();
            }
        }

        public void ResetState()
        {
            lockStateText.text = "LOCKED";
            lockStateImage.color = Color.cyan;
            AudioManager.instance.PlayReset();

            comboLock.Reset();
            state = State.Locked;
        }



        // Animation sequences

        IEnumerator OpenSeq()
        {
            var timer = 0f;
            AudioManager.instance.PlayDone();

            while (timer < 0.5f)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            lockStateText.text = "OPEN";
            lockStateImage.color = Color.green;
            AudioManager.instance.PlayOpen();

            state = State.Opened;
        }

        IEnumerator ResetSeq(string message)
        {
            lockStateText.text = message;
            lockStateImage.color = Color.red;
            AudioManager.instance.PlayIncorrect();

            var timer = 0f;

            while (timer < 1f)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            ResetState();
        }

    }

}



