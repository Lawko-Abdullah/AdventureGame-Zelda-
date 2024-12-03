using System;
using System.Collections.Generic;


namespace AdventureGame
{
    public class GenericRepository<T>
    {
        private List<T> items;

        public GenericRepository()
        {
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public List<T> GetAllItems()
        {
            return items;
        }
    }
}
