namespace Library3
{
    public class DynamicArray<T>
    {
        const int defaultArraySize = 8;
        int count = 0;
        T[] array;

        public DynamicArray()
        {
            array = new T[defaultArraySize];
        }

        public DynamicArray(int size)
        {
            array = new T[size];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            array = new T[collection.Count()];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = collection.ElementAt(i);
            }
        }

        public T GetElement(int index)
        {
            return array[index];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("элемент = null", nameof(element));
            }
            if (Length == Capacity - 1)
            {
                var newArray = new T[Capacity * 2];
                for (var i = 0; i < Capacity; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            array[count] = element;
            count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("коллекция = null", nameof(collection));
            }
            var newArray = new T[count + collection.Count()];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }
            for (int i = count; i < newArray.Length; i++)
            {
                newArray[i] = collection.ElementAt(i);
            }
            array = newArray;
            count = array.Length;
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("элемент = null", nameof(element));
            }
            for (var i = 0; i < count; i++)
            {
                if (element.Equals(GetElement(i)))
                {
                    for (var j = i; j < count; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    count--;
                    return true;
                }
            }
            return false;
        }

        public bool Insert(int index, T element)
        {
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException("Индекс за пределами массива", nameof(index));
            }
            if (element == null)
            {
                throw new ArgumentNullException("элемент = null", nameof(element));
            }
            if (index == count)
            {
                Add(element);
            }
            for (var i = count; i > index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = element;
            count++;
            return true;
        }

        public int Length
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return array.Length; }
        }
    }
}
