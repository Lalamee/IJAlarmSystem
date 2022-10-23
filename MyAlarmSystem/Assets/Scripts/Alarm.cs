using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    
    private float _changeVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(UpVolume());
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(DownVolume());
        }
    }
    
    public IEnumerator UpVolume()
    {
        _alarm.Play();
        
        for (float i = _alarm.volume; i < 1; i += _changeVolume * Time.deltaTime)
        {
            _alarm.volume =  i;
            yield return null;
        }
        
        StopCoroutine(UpVolume());
    }
    
    public IEnumerator DownVolume()
    {
        for (float i = _alarm.volume; i > 0; i -= _changeVolume * Time.deltaTime)
        {
            _alarm.volume =  i;
            yield return null;
        }
        
        _alarm.Stop();
        StopCoroutine(DownVolume());
    }
}
