using MyGameNamespace.Players;
using MyGameNamespace.SaveLoad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Utils
{
    public class PlayerManager : MonoBehaviour, ISaveManager
    {
        public static PlayerManager instance;
        public Player player;

        public int currency;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance.gameObject);
            }
            else
            {
                instance = this;
            }
        }

        public bool HaveEnoughMoney(int _price)
        {
            return currency >= _price;
        }

        public int GetCurrency() => currency;

        public void LoadData(GameData _data)
        {
            this.currency = _data.currency;
        }

        public void SaveData(ref GameData _data)
        {
            _data.currency = this.currency;
        }
    }
}