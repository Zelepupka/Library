namespace Library.BLL.Interfaces
{
    public interface IBaseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}