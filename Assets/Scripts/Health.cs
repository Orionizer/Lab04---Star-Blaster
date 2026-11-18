using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem HitParticle;

    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();

        if (damage != null)
        {
            PlayHitParticles();
            TakeDamage(damage.GetDamage());
            damage.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitParticles()
    {
        if (HitParticle != null)
        {
            ParticleSystem particles = Instantiate(HitParticle, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }

}
