using System;
using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    
    private float _changeVolume = 0.5f;
    private House _house;
    
    private void OnHouseInfiltrated()
    {
        if (_house.IsInfiltrated)
        {
            StopCoroutine(DownVolume());
            StartCoroutine(UpVolume());
        }
        else
        {
            StopCoroutine(UpVolume());
            StartCoroutine(DownVolume());
        }
    }
    
    private IEnumerator UpVolume()
    {
        _alarm.Play();
        
        for (float i = _alarm.volume; i < 1; i += _changeVolume * Time.deltaTime)
        {
            _alarm.volume =  i;
            yield return null;
        }
    }

    private IEnumerator DownVolume()
    {
        for (float i = _alarm.volume; i > 0; i -= _changeVolume * Time.deltaTime)
        {
            _alarm.volume =  i;
            yield return null;
        }
        
        _alarm.Stop();
    }
}
