using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public RectTransform coinPile;

    public void AddCoins()
    {
        coinPile.transform.localScale += new Vector3(0.3f, 0.3f);
        HideCoin();
        resetState();
    }

    public void RemoveCoins()
    {
        coinPile.transform.localScale -= new Vector3(0.3f, 0.3f);
        HideCoin();
        resetState();
    }

    public void ShowCoin()
    {
        GetComponent<RawImage>().enabled = true;
    }

    public void HideCoin()
    {
        GetComponent<RawImage>().enabled = false;
    }

    private void resetState()
    {
        gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("Normal");
    }
}
