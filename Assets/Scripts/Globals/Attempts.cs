using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class Attempts
    {
        public static int PuzzleAttemptCount = 0;

        public static void ResetValues()
        {
            PuzzleAttemptCount = 0;
        }
    }
}