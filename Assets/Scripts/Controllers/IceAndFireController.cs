using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Controllers
{
    public class IceAndFireController : ThunderStrikeController
    {
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}