using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombtileActive : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask layerToHit;
    public GameObject bombBrick;
    public GameObject brick;

    void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement mm = collision.gameObject.GetComponent<MarioMovement>();
        if(mm != null)
        {
            Debug.Log(12);
            if (mm.bombis == true)
            {
                Debug.Log("destroy");
                if (mm.currentSage == 0)
                {
                    LeanTween.moveY(gameObject, transform.position.y + 0.5f, 0.2f).setLoopPingPong(1);
                    mm.bombis = false;
                }
                else
                {
                    brick.SetActive(false);
                    bombBrick.SetActive(true);

                    foreach (var obj in bombBrick.GetComponentsInChildren<Transform>())
                    {
                        Vector2 direction = obj.transform.position - transform.position;
                        obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
                        mm.bombis = false;
                    }
                    Destroy(bombBrick, 1);
                }

            }
        }
      
    }
}
