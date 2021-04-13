using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 750;
    public float gravityModifier;
    private bool isOnGround = true;
    private bool gameOver = false;
    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        dirtParticle.Stop();
        sound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState == GameBaseState.PLAY)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnimator.SetTrigger("Jump_trig");
                sound.PlayOneShot(jumpSound);
                dirtParticle.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gameOver)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                isOnGround = true;
                dirtParticle.Play();
            }
            else
        if (collision.collider.CompareTag("Obstacle"))
            {
                GameManager.Instance.TransitionState(GameBaseState.GAMEOVER);
                explosionParticle.Play();
                playerAnimator.SetBool("Death_b", true);
                playerAnimator.SetInteger("DeathType_int", 1);
                sound.PlayOneShot(crashSound);
                dirtParticle.Stop();
            }
        } 
    }
}
