using System.Collections.Generic;
using Gun;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EntityData", menuName = "Data/EntityStats")]
    public class EntityData : ScriptableObject
    {
        public string Name;
        public float Health;
        public float Damage;
        public float Speed;


        public GunData Gun;


    }
}
