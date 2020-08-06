using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;

public interface IPossesable
{ 
    NetworkGamePlayer posessor{ get; set; }

    void Movement(Vector2 dir);
    void Aiming(Vector2 pos);
    void Fire();
    void Jump();
    void Interact();
    void Action1();
    void Action2();
    void Action3();

}
