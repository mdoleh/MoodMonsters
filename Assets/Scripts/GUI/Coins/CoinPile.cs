using UnityEngine;

public class CoinPile : MonoBehaviour
{
    public static Vector3 currentSize = Vector3.zero;

    private void Start()
    {
        if (currentSize != Vector3.zero) 
            transform.localScale = currentSize;
    }
}
