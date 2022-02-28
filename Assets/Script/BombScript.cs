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
    int z = 0;
    // Start is called before the first frame update
    void Start()
    { 
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        z++;
        if(z == 1)
        {
            Brick.SetActive(false);
            bombBrick.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(z == 1)
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

            foreach (Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
            Debug.Log(2345678);
            Destroy(bombBrick, 1);
        }
    }
     

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
