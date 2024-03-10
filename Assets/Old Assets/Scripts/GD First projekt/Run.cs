using UnityEngine;

public class Run : MonoBehaviour
{
    // Horizontale Bewegungsgeschwindigkeit
    public float speedDelta = 1f;
    private Rigidbody2D rb;
    // Sprunghöhe
    public float jumph = 2;
    private SpriteRenderer spriteRenderer;
    public float gravityScale = 15;
    public float fallingGravityScale = 0;
    public GameObject soundPrefab;
    public ParticleSystem dust;

    // Wird beim Start aufgerufen
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Wird einmal pro Frame aufgerufen
    void Update()
    {

        // Partikelanimation bei Bewegung auf x-Achse
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            bool tempflip = spriteRenderer.flipX;
            spriteRenderer.flipX = horizontal > 0;
            if (spriteRenderer.flipX != tempflip)
            {
                dust.Play();
            }
        }
        transform.position += Vector3.right * (Time.deltaTime * horizontal * this.speedDelta);

        // Sprung und Soundeffekt
        if (rb.velocity.y == 0 && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            GameObject g = Instantiate(soundPrefab);
            Destroy(g, 2F);
        }

        // Kontrolliert die Gravitation des Objekts, damit das Objekt nicht unbegrenzt hoch springen kannS
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        }
        // Kontrolliert die Gravitation des Objekts, wenn das Objekt am Fallen ist
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }
}



