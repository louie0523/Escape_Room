using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float radius;
    public LayerMask targetLayer;
    public Vector3 MoveVecter {
        get
        {
            return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getNpc();
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = MoveVecter * speed;
    }

    public void getNpc()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, targetLayer);
        for(int i = 0; i <hits.Length; i++)
        {
            if(hits[i] != null)
            {
                if (hits[i].transform.TryGetComponent(out Npc npc))
                {
                    Debug.Log(npc.chat);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
