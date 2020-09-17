namespace Shared.Interfaces
{
    public interface IHaveAnId<TId>
    {
        TId Id { get; }
    }
}