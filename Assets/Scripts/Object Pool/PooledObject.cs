using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private ObjectPool pool;
    private float resetTimer;

    public Rigidbody GetRigidbody()

    { return rb; }

    public void LinkPooledObject(ObjectPool linkPool)

    {
        pool = linkPool;
    }

    public void ResetPooledObject()
    {
        rb.velocity = Vector3.zero;
        pool.SendBackToPool(this);

    }


    private void Update()
    {
        if (resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                ResetPooledObject();
            }
        }
    }
    public void ResetPooledObject(float timer)
    {
        Invoke("ResetPooledObject", timer);
    }
    
}
