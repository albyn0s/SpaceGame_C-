using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class MyList<T> : IEnumerable
    {

        T[] list;
        public MyList()
        {
            list = new T[10]; //выделение памяти

            index = 0;
        }

        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
        /// <summary>
        /// получить размер коллекции
        /// </summary>
        public int MyCount{ get => this.index-1; set => this.index = value; }

        private int index;
        /// <summary>
        /// добавить элемент 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (index >= list.Length)
            {
                Array.Resize(ref list, list.Length * 2);
            }
            list[index++] = item;
        }
        /// <summary>
        /// удалить элемент со сдвигом коллекции
        /// </summary>
        /// <param name="value"></param>
        public void RemoveAt(int value)
        {
            int ind = value;
            T[] newList = new T[--index];
            int j = 0;
            for (int i = 0; i < index; i++)
            {
                if (i == ind)
                {
                    j++;
                    continue;
                }
                newList[i-j] = list[i];
            }
            list = newList;
        }

        /// <summary>
        /// для перебора foreach
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < MyCount; i++)
            {
                yield return list[i];
            }
        }
    }
}
