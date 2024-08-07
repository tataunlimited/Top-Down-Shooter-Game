using UnityEngine;

namespace Entity.Components
{
    public interface IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        
    }
}
