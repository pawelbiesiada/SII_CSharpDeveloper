using System;

namespace CSharpConsole.Samples.Class
{
    public class AdvListClass
    {
        // Constant
        const int DefaultCapacity = 4;

        // Fields
        string[] _items;
        int _count;

        // Constructor
        public AdvListClass(int capacity)
        {
            _items = new string[capacity];
        }

        public AdvListClass()
        {
            _items = new string[DefaultCapacity];
        }

        public AdvListClass(EventHandler handler, int capacity = DefaultCapacity) : this(capacity)
        {
            Changed += handler;
        }

        // Properties
        public int Count => _count;

        public int Capacity
        {
            get { return _items.Length; }
            set
            {
                if (value < _count) value = _count;
                if (value != _items.Length)
                {
                    string[] newItems = new string[value];
                    Array.Copy(_items, 0, newItems, 0, _count);
                    _items = newItems;
                }
            }
        }

        // Indexer
        public string this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
                OnChanged();
            }
        }

        // Methods
        public void Add(string item)
        {
            if (_count == Capacity) Capacity = _count * 2;
            _items[_count] = item;
            _count++;
            OnChanged();
        }

        protected virtual void OnChanged() =>
            Changed?.Invoke(this, EventArgs.Empty);

        public override bool Equals(object other) => Equals(this, other as AdvListClass);

        static bool Equals(AdvListClass a, AdvListClass b)
        {
            if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
            if (Object.ReferenceEquals(b, null) || a._count != b._count)
                return false;
            for (int i = 0; i < a._count; i++)
            {
                if (!object.Equals(a._items[i], b._items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // Event
        public event EventHandler Changed;

        // Operators
        public static bool operator ==(AdvListClass a, AdvListClass b) => Equals(a, b);

        public static bool operator !=(AdvListClass a, AdvListClass b)
        {
            return !Equals(a, b);
        }

        //Desctructor
        ~AdvListClass()
        {

        }
    }
}
