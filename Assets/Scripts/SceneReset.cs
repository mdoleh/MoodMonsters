using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoad;
    AudioSource audio;

    void Awake() {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Lily") {
            audio.Play();
        }
    }

    void Update() {
        if (!audio.isPlaying) Application.LoadLevel(sceneToLoad);
    }
}
