using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float health = 2;
    public GameObject killingEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(killingEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
