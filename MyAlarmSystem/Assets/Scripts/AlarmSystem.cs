using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private bool _inHouse;
    private float _changeVolume = 0.25f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _inHouse = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _inHouse = false;
    }

    private void Update()
    {
        if (_inHouse)
            _alarm.volume += _changeVolume * Time.deltaTime;
        else
            _alarm.volume -= _changeVolume * Time.deltaTime;
    }
}
