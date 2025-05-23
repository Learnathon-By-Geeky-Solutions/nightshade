using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.SaveLoad
{
    public interface ISaveManager
    {
        void LoadData(GameData _data);
        void SaveData(ref GameData _data);
    }
}