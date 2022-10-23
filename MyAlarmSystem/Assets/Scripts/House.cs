using UnityEngine;

public class House : MonoBehaviour
{
    public bool IsInfiltrated { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            IsInfiltrated = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            IsInfiltrated = false;
    }
}
