using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void ChangeVolume(float volume) => mixer.SetFloat("Volume", volume);
}