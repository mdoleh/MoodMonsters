using UnityEngine;
using System.Collections;

public class ConeManager : MonoBehaviour
{
    public GameObject[] Cones;

    private int currentIndex = 1;

    public void NextCone()
    {
        if (currentIndex >= Cones.Length) return;
        Cones[currentIndex++].SetActive(true);
    }
}
