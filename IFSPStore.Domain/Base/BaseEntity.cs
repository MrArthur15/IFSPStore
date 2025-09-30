namespace IFSPStore.Domain.Base
{
    public abstract class BaseEntity<TId> : IBaseEntitiy
    {
        public BaseEntity(TId id)
        {
            Id = id;

        }
        public TId Id {  get; set; }

    }
}
