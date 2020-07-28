namespace SmartStore.Domain.Model.Models
{
    public abstract class TEntity<TId>
    {
        public TId Id { get; set; }
    }
}