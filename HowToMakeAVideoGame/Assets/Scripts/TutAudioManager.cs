using UnityEngine.Audio;
using UnityEngine;
using System;

public class TutAudioManager : MonoBehaviour
{

    public Sound[] sounds; //array of sounds
    public static TutAudioManager instance;

    void Awake()
    {
        if(instance == null) //if there isn't a TutAudioManager object yet
        {
            instance = this;
        }
        else
        {//if there is already a TutAudioManager object in the hierarchy, then destroy it to keep just one
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
               

        foreach (Sound s in sounds) //loop throgh array and for each sound add an audio source
        {
            s.source = gameObject.AddComponent<AudioSource>(); //add audio source component
            s.source.clip = s.clip; //the clip of the audio source

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        }

    }

    void Start()
    {
        Play("StartTheme"); //play the start menu and tutorials' background music
    }

    public void Play(string name)
    {
        //loop through all our sounds and find the sound with the appropriate name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)//if there is e.g a typo
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;//we return and no sound is played
        }

        s.source.Play();


    }
}
