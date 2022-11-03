using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private House _house;

    private float _upVolumeValue = 0.5f;
    private float _downVolumeValue = 0.25f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    public void OnOffVolume()
    {
        if (_house.IsInfiltrated)
            _alarm.Play();
        
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_alarm.volume < _maxVolume)
        {
            if (_house.IsInfiltrated)
            {
                _alarm.volume += _upVolumeValue * Time.deltaTime;

                if (_alarm.volume == _maxVolume)
                    StopCoroutine(ChangeVolume());
            }

            yield return null;
        }

        while (_alarm.volume > _minVolume)
        {
            if (_house.IsInfiltrated == false)
            {
                _alarm.volume -= _downVolumeValue * Time.deltaTime;

                if (_alarm.volume == _minVolume)
                {
                    _alarm.Stop();
                    StopCoroutine(ChangeVolume());
                }
            }
            
            yield return null;
        }
    }
}
