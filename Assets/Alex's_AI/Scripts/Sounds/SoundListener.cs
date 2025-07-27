using UnityEngine;

/// <summary>
/// Allows the attached gameobject to hear a sound and trigger an event based off of it
/// </summary>
public class SoundListener : MonoBehaviour
{
   
    public delegate void SoundHandler();
    public event SoundHandler HeardSound_Event;

    public void HeardSound()
    {
        HeardSound_Event?.Invoke();
    }
}
