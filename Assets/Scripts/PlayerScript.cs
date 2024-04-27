using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector2 speed = new Vector2(5, 5);
    Vector2 movement;
    Rigidbody2D rigidbodyComponent;
    private Rigidbody2D _rigidbody2D;
    private WeaponScript _weapon;

    void Start()
    {
        _weapon = GetComponent<WeaponScript>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(
            speed.x * Input.GetAxis("Horizontal"),
            speed.y * Input.GetAxis("Vertical")
        );
        
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            if (_weapon)
            {
                // false because the player is not an enemy
                _weapon.Attack(false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!rigidbodyComponent) rigidbodyComponent = _rigidbody2D;

        rigidbodyComponent.velocity = movement;
    }
}