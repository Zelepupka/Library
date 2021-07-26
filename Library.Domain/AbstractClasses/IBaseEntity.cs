namespace Library.Domain.AbstractClasses
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }

}