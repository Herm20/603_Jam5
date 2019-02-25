using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootbox : MonoBehaviour
{
    public GameObject[] items;
    public Color[] spawnColors;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + new Vector3(0.0f, Time.deltaTime, 0.0f);
	}

    private void Awake()
    {
        GetComponent<SpriteRenderer>().color = spawnColors[Random.Range(0, spawnColors.Length)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            GameObject newItem = Instantiate(items[Random.Range(0, items.Length)], transform.position, Quaternion.identity);

            player.GetItem(newItem.GetComponent<Item>());

            Destroy(gameObject);
        }
    }
}
