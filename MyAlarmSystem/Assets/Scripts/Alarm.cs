using System;
using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    
    private float _changeVolumeValue = 0.5f;
    private House _house;

    public void OnOffVolume()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_alarm.volume < 1 || _alarm.volume > 0)
        {
            if (_house.IsInfiltrated)
            {
                _alarm.volume += _changeVolumeValue * Time.deltaTime;

                if (_alarm.volume == 1)
                {
                    StopCoroutine(ChangeVolume());
                }
            }
            else
            {
                _alarm.volume -= _changeVolumeValue * Time.deltaTime;
                
                if (_alarm.volume == 0)
                {
                    _alarm.Stop();
                    StopCoroutine(ChangeVolume());
                }
            }
        }
        for (float i = _alarm.volume; i < 1; i += _changeVolumeValue * Time.deltaTime)
        {   
            _alarm.volume =  i;
            yield return null;
        }
    }

    private IEnumerator DownVolume()
    {
        for (float i = _alarm.volume; i > 0; i -= _changeVolumeValue * Time.deltaTime)
        {
            _alarm.volume =  i;
            yield return null;
        }
        
        _alarm.Stop();
    }
}
