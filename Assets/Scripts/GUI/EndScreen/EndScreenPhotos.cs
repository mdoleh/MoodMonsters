using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EndScreen
{
    public class EndScreenPhotos : MonoBehaviour
    {
        public RawImage[] images;
        public AudioSource completedAudio;
        private static readonly List<Texture2D> PhotoCollection = new List<Texture2D>();

        public static void AddPhoto(Texture2D photo)
        {
            PhotoCollection.Add(photo);
        }

        private void Start()
        {
            for (var i = 0; i < PhotoCollection.Count; ++i)
            {
                images[i].texture = PhotoCollection[i];
            }
            Utilities.PlayAudio(completedAudio);
        }
    }
}