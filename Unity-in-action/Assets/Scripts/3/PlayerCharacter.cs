using System;
using _12;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;

    private void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Managers.Player.ChangeHealth(-damage);
    }
}
