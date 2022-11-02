using System;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    public bool IsInfiltrated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = true;
            _alarm.OnOffVolume();
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = true;
            _alarm.OnOffVolume();
            IsInfiltrated = false;
            _alarm.OnOffVolume();
        }
    }*/
}
