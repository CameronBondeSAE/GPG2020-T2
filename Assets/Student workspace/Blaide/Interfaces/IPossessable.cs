using System.Collections;
using System.Collections.Generic;
using Student_workspace.Dylan.Scripts.NetworkLobby;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This is an Interface used specifically for the networkGamePlayer possessing, Essentially Controls are handled by passing through this to whatever the network player should be controlling.
/// </summary>
public interface IPossessable
{ 
    
    NetworkGamePlayer possessor{ get; set; }
/// <summary>
/// Movement control passed from GameNetworkPlayer.
/// </summary>
/// <param name="dir">Just a shortcut for ctx.ReadValue </param>
/// <param name="ctx">Passed through callback context from the inputsystem, Use this to determine the input phase for performed or canceled etc.</param>
    void Movement(Vector2 dir,InputAction.CallbackContext ctx);
/// <summary>
/// Aiming control passed from GameNetworkPlayer.
/// </summary>
/// <param name="Pos">Just a shortcut for ctx.ReadValue </param>
/// <param name="ctx">Passed through callback context from the inputsystem, Use this to determine the input phase for performed or canceled etc.</param>
    void Aiming(Vector2 pos,InputAction.CallbackContext ctx);
/// <summary>
/// Fire Action passed from GameNetworkPlayer.
/// </summary>
/// <param name="ctx"></param>
    void Fire(InputAction.CallbackContext ctx);
    void Jump(InputAction.CallbackContext ctx);
    void Interact(InputAction.CallbackContext ctx);
    void Action1(InputAction.CallbackContext ctx);
    void Action2(InputAction.CallbackContext ctx);
    void Action3(InputAction.CallbackContext ctx);

}
