using JetBrains.Annotations;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static SoundManagerScript instance;

    public AudioSource coinSound;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCollectCoinSound()
    {
        coinSound.Play();
    }
}
