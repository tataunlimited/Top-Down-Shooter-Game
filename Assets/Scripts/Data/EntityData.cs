using System.Collections.Generic;
using GameCore.Gun;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Data/EntityStats")]
    public class EntityData : ScriptableObject
    {
        public string Name;
        public float Health;
        public float Speed;
        public BaseGun Gun;


    }
}
