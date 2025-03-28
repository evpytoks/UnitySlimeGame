using GameUtils;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected virtual void ApplyEffect(GameObject player) {}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
    }
}