namespace Library.Domain.AbstractClasses
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }

}