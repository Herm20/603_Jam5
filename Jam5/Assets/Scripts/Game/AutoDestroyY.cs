using UnityEngine;

public class AutoDestroyY : MonoBehaviour
{
    [SerializeField] private float offset = -20;
    [SerializeField] private GameObject target;

    private void FixedUpdate()
    {
        if (transform.position.y < Camera.main.transform.position.y + offset)
            Destroy(target ? target : gameObject);
    }
}
