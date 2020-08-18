using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPossessable
{ 
    NetworkGamePlayer possessor{ get; set; }

    void Movement(Vector2 dir,InputAction.CallbackContext ctx);
    void Aiming(Vector2 pos,InputAction.CallbackContext ctx);
    void Fire(InputAction.CallbackContext ctx);
    void Jump(InputAction.CallbackContext ctx);
    void Interact(InputAction.CallbackContext ctx);
    void Action1(InputAction.CallbackContext ctx);
    void Action2(InputAction.CallbackContext ctx);
    void Action3(InputAction.CallbackContext ctx);

}
