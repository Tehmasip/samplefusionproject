using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class Player : NetworkBehaviour
{
    [SerializeField] private Ball Ball;
    

    public override void Spawned()
    {
        base.Spawned();
       // Spawnball();
    }
    public void Spawnball(int num)
    {
        if (HasStateAuthority)
        {
            for(int i =0; i<num;i++)
            {
                Runner.Spawn(Ball, BallGameManager.Instance.points[BallGameManager.Instance.index].position, Quaternion.identity, Object.InputAuthority,
           (Runner, o) =>
           {
               o.GetComponent<Ball>().Init(new Vector3(0, 0, -1));
           }

           );
                BallGameManager.Instance.index++;
            }
           
        }
    }
}
