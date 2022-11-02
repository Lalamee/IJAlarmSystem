using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;
    public bool IsInfiltrated { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = true;
            _alarm.OnOffVolume(IsInfiltrated);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = false;
            _alarm.OnOffVolume(IsInfiltrated);
        }
    }
}
