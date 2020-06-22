namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class IndexedItem<T>
    {
        public IndexedItem(int index, T item)
        {
            Index = index;
            Item = item;
        }

        public int Index { get; }

        public T Item { get; }
    }
}