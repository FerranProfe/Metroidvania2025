using Unity.VisualScripting;
using UnityEngine;

public class PolillaController : EnemyController
{
    [SerializeField]
    private GameObject bolaPrefab;
    [SerializeField]
    private Transform spawnPoint;
    private bool chocadoSuelo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (estoymuerto == true)
        {
            if (chocadoSuelo == false)
            {
                rb.gravityScale = 1.0f;
                GetComponent<Collider2D>().enabled = true;
            }
            GetComponent<Collider2D>().offset = new Vector2(0.0871594f, 0.9f);
            return;
        }

        if (player == null)
        {
            return;
        }

        Vector3 distancia = (player.position + Vector3.up) - transform.position;
        if (distancia.x > 0)//derecha
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (distancia.x < 0)//izquierda
        {
            transform.eulerAngles = Vector3.zero;
        }

        if (playerDetected == true && attacking == false)
        {

            rb.linearVelocity = speed * distancia.normalized;

            Vector3 distance = player.position - transform.position;
            float distanceSQR = distance.sqrMagnitude;
            if (distanceSQR <= Mathf.Pow(stopDistance, 2))
            {
                attacking = true;
                rb.linearVelocity = Vector2.zero;
            }
        }
        if (attacking == true)
        {
            animator.SetBool("Attacking", true);
            Vector3 distance = player.position - transform.position;
            float distancesqr = distance.sqrMagnitude;
            if (distancesqr > Mathf.Pow(stopDistance, 2))
            {
                attacking = false;
                animator.SetBool("Attacking", false);
            }
        }
    }

    public void ShotBola()
    {
        spawnPoint.LookAt(player.position + Vector3.up);
        spawnPoint.Rotate(new Vector3(0, -90, 0));
        Instantiate(bolaPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisiono contra algo");
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag=="Ground" && estoymuerto==true)
        {
            chocadoSuelo = true;
            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0.0f;
            animator.SetTrigger("ChocoSuelo");
        }
    }

    public void TotallyDeath()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
