using GameCore.Entity.Components;

namespace GameCore.Entity
{
    public class EnemyEntity : BaseEntity
    {
        private AIController _aiController;

        protected override void CacheComponents()
        {
            base.CacheComponents();
            CacheComponent(ref _aiController);
        }
    }
}
