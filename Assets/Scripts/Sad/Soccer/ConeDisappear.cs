using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class ConeDisappear : MonoBehaviour
{
    private bool shouldSink = false;
    private float alpha = 1.0f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name.ToLower().Equals("soccerball"))
        {
            StartCoroutine(DestroyObject());
        }
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
