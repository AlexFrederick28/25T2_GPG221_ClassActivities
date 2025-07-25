using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundMaker : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    [SerializeField] private bool playOneShot = false;
    [SerializeField] private bool playLooping = false;

    [SerializeField] private float emitterRadius = 20f;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if (playOneShot)
        {
            audioSource.PlayOneShot(clip);
        }
        else if (playLooping)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void EmitSoundwave()
    {
        Collider[] results = new Collider[50];

        Physics.OverlapSphereNonAlloc(transform.position, emitterRadius, results);

        foreach (Collider result in results)
        {
            if (result != null)
            {
                SoundListener soundListener = result.GetComponentInChildren<SoundListener>();

                if (soundListener != null)
                {
                    soundListener.HeardSound();
                }

            }

        }

    }
}
