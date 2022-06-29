using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Audio : MonoBehaviour
{
    public AudioClip grab, drop, footsteps;
    List<AudioSource> sources = new List<AudioSource> { };
    AudioSource footstepSource, backgroundSource;

    public AudioClip backgroundSound;
    public bool playBackgroundSoundOnStart;
    public float backgroundVolume = 0.5f;

    public static Audio instance;
    Transform player;
    bool moving = false;
    Vector3 storedPosition;
    float timer = 0;
    private void Awake()
    {
        instance = this;
        sources.AddRange(gameObject.GetComponents<AudioSource>());

        backgroundSource = sources[0];
        footstepSource = sources[1];
        sources.RemoveAt(1);
        sources.RemoveAt(0);

        backgroundSource.loop = true;
        footstepSource.loop = true;
    }

    private void Start()
    {
        if (playBackgroundSoundOnStart && backgroundSound != null)
        {
            SetBackgroundNoise(backgroundSound);
        }
        SetBackgroundVolume(backgroundVolume);

        footstepSource.clip = footsteps;

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (timer > 0.1f)
        {
            timer = 0;

            bool movedThisFrame = true;
            if (Vector3.Distance(player.position, storedPosition) < 0.01f)
            {
                movedThisFrame = false;
            }

            if (movedThisFrame != moving)
            {
                if (movedThisFrame) { footstepSource.Play(); }
                else { footstepSource.Stop(); }
                moving = movedThisFrame;
            }


            storedPosition = player.position;
        }
        timer += Time.deltaTime;
    }

    public void SetBackgroundVolume(float v)
    {
        backgroundSource.volume = v;
    }

    public void Grab()
    {
        PlayOnce(grab);
    }

    public void Drop()
    {
        PlayOnce(drop);
    }

    public void SetBackgroundNoise(AudioClip clip)
    {
        backgroundSource.clip = clip;
        backgroundSource.Play();
    }

    void Play(AudioClip clip, bool loop, AudioSource source)
    {
        if (source == null) { return; }

        source.clip = clip;
        source.loop = loop;
        source.Play();
    }

    public void PlayOnce(AudioClip clip)
    {
        Play(clip, false, GetSource());
    }

    public void PlayLoop(AudioClip clip)
    {
        Play(clip, true, GetSource());

    }

    public void Stop(AudioClip play)
    {
        foreach (AudioSource source in sources)
        {
            if (source.clip == play)
            {
                source.Stop();
            }
        }
    }

    AudioSource GetSource()
    {
        foreach (AudioSource source in sources)
        {
            if (!source.isPlaying) { return source; }
        }
        return null;
    }
}
