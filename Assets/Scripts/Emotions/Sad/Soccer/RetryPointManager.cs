using System.Linq;

namespace SadScene
{
    // Controls which Retry point is active at a given time
    public class RetryPointManager : ObjectSequenceManager
    {
        public ObjectSequenceManager coneManager;
        
        public override void NextInSequence()
        {
            if (RetryPoint.PreviousRetryPoint != null && 
                SequenceObjects.ToList().IndexOf(RetryPoint.PreviousRetryPoint) + 1 == coneManager.currentIndex)
            {
                RetryPoint.PreviousRetryPoint.SetActive(true);
            }
            else
            {
                // use the index as is if the coneManager is at the end of its sequence objects
                if (coneManager.currentIndex == coneManager.SequenceObjects.Length)
                    currentIndex = coneManager.currentIndex;
                else
                    currentIndex = coneManager.currentIndex - 1;
                base.NextInSequence();
            }
        }
    }
}
