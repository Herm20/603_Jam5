using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Balloon"))
            Destroy(collision.transform.parent.gameObject);
        else if (collision.tag == "Player")
            collision.GetComponent<PlayerController>().Die();
    }
}
