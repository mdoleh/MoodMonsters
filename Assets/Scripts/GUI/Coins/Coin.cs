using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public RectTransform coinPile;
    public AudioSource correctSound;
    public AudioSource wrongSound;

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

    public void ShowAddCoinAnimation()
    {
        showAnimation("Add");
        Utilities.PlayAudioUnBlockable(correctSound);
    }

    public void ShowRemoveCoinAnimation()
    {
        showAnimation("Remove");
        Utilities.PlayAudioUnBlockable(wrongSound);
    }

    private void showAnimation(string trigger)
    {
        GetComponent<Animator>().gameObject.SetActive(true);
        GetComponent<Animator>().SetTrigger(trigger);
    }

    private void resetState()
    {
        gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("Normal");
        CoinPile.currentSize = coinPile.transform.localScale;
    }
}
