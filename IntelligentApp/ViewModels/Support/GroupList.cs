using System.Collections.ObjectModel;
namespace System.Collections.Generic
{
    public class GroupList<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { get; private set; }

        public GroupList(TKey key, IEnumerable<TItem> items)
        {
            this.Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
