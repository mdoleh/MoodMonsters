﻿using UnityEngine;
using System.Collections;

namespace Globals
{
    public static class Tutorials
    {
        public static bool MainTutorialHasRun = false;

        public static void ResetValues()
        {
            MainTutorialHasRun = false;
        }
    }
}