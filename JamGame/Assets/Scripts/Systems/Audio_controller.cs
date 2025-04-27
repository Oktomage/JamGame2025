using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Audios
{
    public class Audio_controller : MonoBehaviour
    {
        public static void Play_audio(string audio_name)
        {
            GameObject new_obj = new GameObject(audio_name);

            //Add
            new_obj.AddComponent<AudioSource>();

            //Set
            new_obj.GetComponent<AudioSource>().clip = Resources.Load("Sounds/" + audio_name) as AudioClip;

            new_obj.GetComponent<AudioSource>().Play();
        }

        public static void Play_audio(string audio_name, float volume)
        {
            GameObject new_obj = new GameObject(audio_name);

            //Add
            new_obj.AddComponent<AudioSource>();

            //Set
            new_obj.GetComponent<AudioSource>().clip = Resources.Load("Sounds/" + audio_name) as AudioClip;
            new_obj.GetComponent<AudioSource>().volume = volume;

            new_obj.GetComponent<AudioSource>().Play();
        }
    }
}

