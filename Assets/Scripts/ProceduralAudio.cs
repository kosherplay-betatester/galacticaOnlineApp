using UnityEngine;

public class ProceduralAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = CreateSineWave(440, 1);
        audioSource.Play();
    }

    AudioClip CreateSineWave(float frequency, float duration)
    {
        int sampleRate = 44100;
        int sampleLength = (int)(sampleRate * duration);
        float[] samples = new float[sampleLength];

        for (int i = 0; i < sampleLength; i++)
        {
            samples[i] = Mathf.Sin(2 * Mathf.PI * frequency * i / sampleRate);
        }

        AudioClip audioClip = AudioClip.Create("SineWave", sampleLength, 1, sampleRate, false);
        audioClip.SetData(samples, 0);
        return audioClip;
    }
}
