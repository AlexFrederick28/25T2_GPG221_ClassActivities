using UnityEngine;

public class SoundListener : MonoBehaviour
{
   
    public delegate void SoundHandler();
    public event SoundHandler HeardSound_Event;

    public void HeardSound()
    {
        HeardSound_Event?.Invoke();
    }
}
