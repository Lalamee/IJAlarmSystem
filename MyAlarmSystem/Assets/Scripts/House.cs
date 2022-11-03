using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _infiltrated;
    
    public bool IsInfiltrated { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = true;
            _infiltrated?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsInfiltrated = false;
            _infiltrated?.Invoke();
        }
    }
}
