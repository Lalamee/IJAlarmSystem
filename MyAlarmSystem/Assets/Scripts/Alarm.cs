using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _upVolumeValue = 0.5f;
    private float _downVolumeValue = 1.8f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;
    
    public void OnOffVolume(bool IsInfiltrated)
    {
        if (IsInfiltrated)
            _alarm.Play();
        
        StartCoroutine(ChangeVolume(IsInfiltrated));
    }

    private IEnumerator ChangeVolume(bool IsInfiltrated)
    {
        while (_alarm.volume < _maxVolume || _alarm.volume > _minVolume)
        {
            if (IsInfiltrated)
            {
                _alarm.volume += _upVolumeValue * Time.deltaTime;
            }
            else
            {
                _alarm.volume -= _downVolumeValue * Time.deltaTime;
            }
            
            yield return null;
        }
        
        StopCoroutine(ChangeVolume(IsInfiltrated));
    }
}
