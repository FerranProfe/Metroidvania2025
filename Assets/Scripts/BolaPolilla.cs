using UnityEngine;

public class BolaPolilla : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Le hace pupa al player
            Debug.Log("Le doy al player");
            collision.GetComponent<PlayerController>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
