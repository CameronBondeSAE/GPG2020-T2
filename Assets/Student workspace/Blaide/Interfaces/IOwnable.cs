using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public interface IOwnable
{
    NetworkIdentity Owner { get; set; }
}
