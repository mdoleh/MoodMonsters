﻿using UnityEngine;
using System.Collections;

namespace Globals
{
    public class Attempts : MonoBehaviour
    {
        public static int PuzzleAttemptCount = 0;

        public static void ResetValues()
        {
            PuzzleAttemptCount = 0;
        }
    }
}