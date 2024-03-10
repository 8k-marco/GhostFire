using UnityEngine;

public class FireBall : MonoBehaviour
{

    // Horizontale Bewegungsgeschwindigkeit
    [SerializeField] private float speedDelta;

    private Rigidbody2D physics;
    private Vector3 direction;

    void Awake()
    {
        physics = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
    }

    // Anpassen der Feuerball-Geschwindigkeit
    void Update()
    {
        this.physics.velocity = direction * this.speedDelta;
    }

    // Änderung der Richtung des Feuerballs auf der x-Achse
    public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
        if (dir.x < 0)
        {
            transform.localScale *= -1;
        }
    }

    // Bei einer Kollision mit dem Feuerball nimmt der Boss 100 schaden
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Run>() != null) return;
        other.GetComponent<BossHealth>().TakeDamage(100);
        gameObject.SetActive(false);
    }
}
