using UnityEngine;
using System.Collections;

public class Mushroom : Bonus
{
    [SerializeField] private float speedMultiplier = 1.2f;

    protected override void ApplyEffect(GameObject player)
    {
        Player.Instance.ChangeSpeed(speedMultiplier);
    }
}