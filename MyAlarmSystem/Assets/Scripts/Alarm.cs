using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private House _house;

    private Coroutine _changeVolumeAlarm;
    private float _changeVolumeValue = 0.5f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    public void ControlCoroutine()
    {
        if (_changeVolumeAlarm != null)
            StopCoroutine(_changeVolumeAlarm);
        
        if (_house.IsInfiltrated)
        {
            _sound.Play();
            _changeVolumeAlarm = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            _changeVolumeAlarm = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_sound.volume != target)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume,target,_changeVolumeValue * Time.deltaTime);
            
            yield return null;
        }
        
        if (_sound.volume == _minVolume)
            _sound.Stop();
            
        StopCoroutine(_changeVolumeAlarm);
    }
}
