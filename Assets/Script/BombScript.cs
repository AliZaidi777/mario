using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject bombBrick;
    public GameObject Brick;
    public GameObject bombBrick1;
    public GameObject Brick1;
    int z,x;
    // Start is called before the first frame update
    void Start()
    { 
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "brick1")
        {
            z++;
            if (z == 3)
            {
                Brick.SetActive(false);
                bombBrick.SetActive(true);

            }
        }
        if (collision.gameObject.tag == "brick")
        {
            x++;
            if (x == 3)
            {
                Brick1.SetActive(false);
                bombBrick1.SetActive(true);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (z == 3)
        {
             Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            Destroy(bombBrick, 1);
        }
        if (x == 3)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            Destroy(bombBrick1, 1);
        }
    }
     

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
