using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody2D monsterbody;

    private void Awake()
    {
        monsterbody = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        monsterbody.velocity = new Vector2(speed, monsterbody.velocity.y);

    }
}
