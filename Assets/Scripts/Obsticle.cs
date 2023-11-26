using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : PlayerInteractable
{
    protected override void OnPlayerTouch(Collider2D collision)
    {
        collision.gameObject.SendMessage("OnPlayerHitObsticle");
    }
}
