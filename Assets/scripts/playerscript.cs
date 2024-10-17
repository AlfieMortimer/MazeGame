using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerscript : MonoBehaviour
{
    public AiscriptFSM Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy.sm.ChangeState(Enemy.attackState);
    }
}
