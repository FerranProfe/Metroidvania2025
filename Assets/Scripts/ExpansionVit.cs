using System.Collections;
using UnityEngine;

public class ExpansionVit : MonoBehaviour
{
    [SerializeField]
    private float lifeToAdd;
    [SerializeField]
    private string expansionVitName;
    [SerializeField]
    private float howMuchMoveInAnim;
    [SerializeField]
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (expansionVitName)
        {
            case "Vit1":
                if (GameManager.instance.GetGameData.ExpansionVit1 == true)
                {
                    Destroy(gameObject);
                }
                break;
            case "Vit2":

                break;
            case "Vit3":

                break;
        }

        StartCoroutine(AnimObject());
    }

    IEnumerator AnimObject()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = transform.position + new Vector3 (0, howMuchMoveInAnim,0);
        float t = 0;
        while (t < 1)
        {
            transform.position=Vector3.Lerp (startPos, endPos, t);
            t += Time.unscaledDeltaTime*speed;
            yield return null;
        }
        while (t > 0)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t);
            t -= Time.unscaledDeltaTime * speed;
            yield return null;
        }
        StartCoroutine (AnimObject());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (expansionVitName)
            {
                case "Vit1":
                    GameManager.instance.GetGameData.ExpansionVit1 = true;
                    GameManager.instance.GetGameData.PlayerLife += lifeToAdd;
                    GameManager.instance.GetGameData.PlayerMaxLife += lifeToAdd;
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().UpdateLife();
                    break;
                case "Vit2":

                    break;
                case "Vit3":

                    break;
            }
        }
    }
}
