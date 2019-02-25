using UnityEngine;

public class AutoDestroyX : MonoBehaviour
{
    [SerializeField] private bool larger = true;
    [SerializeField] private float offset = 30;
    [SerializeField] private GameObject target;

    private void FixedUpdate()
    {
        if (larger)
            if (transform.position.x > offset)
                Destroy(target ? target : gameObject);
        else if (transform.position.x < offset)
                Destroy(target ? target : gameObject);
    }
}
