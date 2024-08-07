using GameCore.Gun;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GunData", menuName = "Data/GunData")]
    public class GunData : ScriptableObject
    {
        public Bullet BulletPrefab;
        public BulletData BulletData;
        public float FireRate;
    }
}
