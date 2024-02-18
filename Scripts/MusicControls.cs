using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControls : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] sounds;
    private AudioSource source;
    public AudioSource death;
    public GameObject player;
    public GameObject respawnBar;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source = sounds[Random.Range(0, sounds.Length)];
        source.Play();

    }


}
