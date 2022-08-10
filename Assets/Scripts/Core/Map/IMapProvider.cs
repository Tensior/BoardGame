namespace Core.Map
{
    public interface IMapProvider
    {
        Node StartNode { get; }
        Node FinishNode { get; }
    }
}