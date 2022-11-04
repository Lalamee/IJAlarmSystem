using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private House _house;

    private Coroutine _changeVolumeAlarm;
    private float _changeVolumeValue = 0.5f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    public void OnOffVolume()
    {
        if (_changeVolumeAlarm != null)
        {
            StopCoroutine(_changeVolumeAlarm);
        }
        
        if (_house.IsInfiltrated)
        {
            _alarm.Play();
            _changeVolumeAlarm = StartCoroutine(ChangeVolume(_maxVolume));
        }
        else
        {
            _changeVolumeAlarm = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_alarm.volume != target)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume,target,_changeVolumeValue * Time.deltaTime);
            
            yield return null;
        }
        
        if (_alarm.volume == _minVolume)
            _alarm.Stop();
            
        StopCoroutine(_changeVolumeAlarm);
    }
}
