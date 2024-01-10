class MyDictionary<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>> items;

    public MyDictionary()
    {
        items = new List<KeyValuePair<TKey, TValue>>();
    }

    public void Add(TKey key, TValue value)
    {
        items.Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public TValue this[TKey key]
    {
        get
        {
            foreach (var item in items)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    return item.Value;
                }
            }
            throw new KeyNotFoundException("Key not found.");
        }
    }

    public int Count
    {
        get { return items.Count; }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return items.GetEnumerator();
    }
}
