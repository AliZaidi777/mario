using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject bombBricks;
    public float force = 4f;

    public void PlayerHit(int currentStage)
    {
        if(currentStage == 0)
        {
            LeanTween.moveY(gameObject, transform.position.y + 0.2f, 0.1f).setLoopPingPong(1);
        }
        else
        {
            Collider2D[] collider2Ds = GetComponentsInChildren<Collider2D>();

            for (int i = 0; i < collider2Ds.Length; i++)
            {
                collider2Ds[i].enabled = false;
            }

            GetComponent<SpriteRenderer>().enabled = false;

            bombBricks.SetActive(true);

            foreach (var obj in bombBricks.GetComponentsInChildren<Rigidbody2D>())
            {
                Vector2 direction = obj.transform.position - bombBricks.transform.position;
                obj.AddForce(direction * force);
            }

            Destroy(gameObject, 1);
        }
    }
}
