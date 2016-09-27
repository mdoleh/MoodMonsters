﻿using UnityEngine;
using System.Collections;

namespace AngryScene
{
    // Incorrect option choice for SituationActions
    public class TakeItBack : ActionBase
    {
        public Animator other;
        public GameObject ipad;
        public Transform leftHand;
        public Transform rightHand;
        private bool takingTriggered = false;

        public void StartTaking()
        {
            takingTriggered = true;
            anim.SetTrigger("IsActingOut");
            other.SetTrigger("IsLosingIPad");
            StartCoroutine(ResetScene());
        }

        private IEnumerator ResetScene()
        {
            yield return new WaitForSeconds(4f);
            sceneReset.TriggerSceneReset(actionExplanation, true);
        }

        public void MoveIpad()
        {
            if (!takingTriggered) return;
            ipad.transform.parent = rightHand;
            ipad.transform.localPosition = new Vector3(-0.104f, 0.122f, 0.114f);
            ipad.transform.localRotation = Quaternion.Euler(26.3481f, 234.883f, 349.391f);
        }

        public void ShiftToLeftHand()
        {
            if (!takingTriggered) return;
            ipad.transform.parent = leftHand;
            ipad.transform.localPosition = new Vector3(0.055f, 0.114f, 0.139f);
            ipad.transform.localRotation = Quaternion.Euler(26.44561f, 105.5384f, 11.9465f);
        }

        public void StartUsingIPad()
        {
            anim.SetBool("IsUsingIPad", true);
            other.SetTrigger("IsAngry");
        }

        public override void StartAction()
        {
            base.StartAction();
            StartTaking();
        }
    }
}