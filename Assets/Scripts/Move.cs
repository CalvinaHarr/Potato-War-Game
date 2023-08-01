using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public string name;
    public float damage;
    public float accuracy;
    public int repetitions;
    public bool stuns;
    public Unit user,target;
    
    void OnMouseEnter()
    {
        user.currentMove = this;
        Debug.Log("Move used!");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}