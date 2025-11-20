using UnityEngine;

public class PalancaPuerta : MonoBehaviour
{
    private bool activated;
    [SerializeField]
    private Animator doorAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = GameManager.instance.GetGameData.PalancaPuerta;
        if (activated)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            doorAnim.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name== "SwordCollider" && !activated)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            doorAnim.SetBool("Open", true);
            GameManager.instance.GetGameData.PalancaPuerta = true;
        }
    }
}
