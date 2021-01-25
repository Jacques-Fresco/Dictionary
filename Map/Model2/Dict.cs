using System;
using System.Collections;
using System.Collections.Generic;

namespace Map.Model2
{
    class Dict<TKey, TValue> : IEnumerable
    {
        private int size = 10;
        private List<TKey> list = new List<TKey>();

        private Model1.Item<TKey, TValue>[] Items; 
        public Dict() 
        {
            Items = new Model1.Item<TKey, TValue>[size];
        }
        public void Add(Model1.Item<TKey, TValue> item)
        {
            if (list?.Contains(item.Key) ?? false) return;

            int hash = GetHash(item.Key); // Получаем хеш ключа

            // Проверяем, есть ли в нашем массиве элемент с таким хэшом\ключом
            // если нет, то записываем элемент в ячейку
            if (Items[hash] == null) 
            {
                Items[hash] = item;
                list.Add(item.Key);
            }
            // если есть, следуем дальше по массиву ища ближайшую следующую свободную ячейку
            // параллельно проверяя Key у элементов сравнивая с item.Key
            // и если такой ключ уже есть, то вызываем return
            else // если мы столкнулись с коллизией
            {
                for(int i = hash + 1; i < size; i++)
                {
                    if (Items[i] == null) // если следующая ячейка равна null, тогда записываем в неё элемент, и устанавливаем флаг true 
                    {
                        Items[i] = item;
                        list.Add(item.Key);
                        return;
                    }
                }

                for (int i = 0; i < hash; i++)
                {
                    if (Items[i] == null) // если находим пустую ячейку, то записываем туда элемент и прерываем цикл
                    {
                        Items[i] = item;
                        list.Add(item.Key);
                        return;
                    }
                }

                throw new Exception("Словарь заполнен.");
            }
        }
        public void Remove(TKey key)
        {
            if (!list.Contains(key)) return;
            int hash = GetHash(key);

            Del(key, hash);
            for (int i = hash + 1; i < size; i++) if (Del(key, i)) return;
            for (int i = 0; i < hash; i++) if (Del(key, i)) return;
        }
        public TValue Search(TKey key)
        {
            TValue outV = default;
            if (!list.Contains(key)) return outV;
            int hash = GetHash(key);

            if(Sea(key, hash, ref outV)) return outV;
            for (int i = hash + 1; i < size; i++) if (Sea(key, i, ref outV)) return outV;
            for (int i = 0; i < hash; i++) if (Sea(key, i, ref outV)) return outV;
            return outV;
        }
        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
        private bool Del(TKey key, int i)
        {
            if (Items[i]?.Key.Equals(key) ?? false)
            {
                list.Remove(key);
                Items[i] = null;
                return true;
            }
            return false;
        }
        private bool Sea(TKey key, int i, ref TValue outV)
        {
            if (Items[i]?.Key.Equals(key) ?? false)
            {
                outV = Items[i].Value;
                return true;
            }
            return false;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (Model1.Item<TKey, TValue> item in Items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }
    }
}
