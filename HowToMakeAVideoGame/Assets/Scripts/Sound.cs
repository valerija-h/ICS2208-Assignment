using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound :System.Object //non monobehavior
{
    public string name; //name for clip
    public AudioClip clip;

    [Range(0f,1f)] //sliders for volume and pitch
    public float volume;
    [Range(.1f, 3)]
    public float pitch;

    public bool loop; //make the theme song loop

    [HideInInspector] //to not show in inspector 
    public AudioSource source;
}
