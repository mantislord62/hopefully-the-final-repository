using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public DetectionZone attackZone;
    public int healthRestore = 25;
    Animator animator;
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if (wasHealed)
                Debug.Log(collision.name + " healed for " + healthRestore);

            if (wasHealed) 
                Destroy(gameObject);
        }
    }
    public bool _hasTarget = false;

    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }
    public void Update()
    {
        HasTarget = attackZone.DetectedColliders.Count > 0;
    }
}
