using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuMusic, gameMusic;
    public bool isMuted = false;

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusic(AudioClip music)
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void ChangePitch(float value)
    {
        audioSource.pitch = value;
    }

    public void FadeVolume(bool fade)
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
            animator.SetTrigger(fade ? "In" : "Out");
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }
}
