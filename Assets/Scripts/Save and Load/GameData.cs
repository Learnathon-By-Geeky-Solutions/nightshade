using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.SaveLoad
{
    [System.Serializable]
    public class GameData
    {
        public int currency;
        public Dictionary<string, int> inventory;

        public GameData()
        {
            this.currency = 0;
            inventory = new Dictionary<string, int>();
        }
    }
}