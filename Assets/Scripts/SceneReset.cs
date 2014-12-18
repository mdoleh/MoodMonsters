using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour {
    public string sceneToLoad;
    AudioSource audio;
    bool startedPlaying = false;

    void Awake() {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Lily") {
            audio.Play();
            startedPlaying = true;
        }
    }

    void Update() {
        if (startedPlaying && !audio.isPlaying) Application.LoadLevel(sceneToLoad);
    }
}
