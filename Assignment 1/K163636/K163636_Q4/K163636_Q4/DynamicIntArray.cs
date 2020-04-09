using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q4
{
    class DynamicIntArray<T>
    {
        private int Size = 0;
        private int Capacity;
        private T[] ArrayGeneric;
        private static int CurrentItem = 0;
        public DynamicIntArray()
        {
            this.Capacity = 10;
            ArrayGeneric = new T[Capacity];
            Console.WriteLine("Array Created with size " + Capacity);
        }
        public DynamicIntArray(int size)
        {
            this.Capacity = size;
            ArrayGeneric = new T[Capacity];
            Console.WriteLine("Array Created with size " + Capacity);
        }
        public void AddElement(T element)
        {
            if (!isFull())
            {
                //Console.WriteLine("Inserting Element");
                ArrayGeneric[CurrentItem] = element;
                CurrentItem++;
            }
            else
            {
                //Console.WriteLine("Resizing And Inserting Element");
                Array.Resize(ref ArrayGeneric, ArrayGeneric.Length + 1);
                ArrayGeneric[CurrentItem] = element;
                Capacity++;
                CurrentItem++;
            }
        }

        public T getElement(int i)
        {
            return ArrayGeneric[i];
        }
        public int indexOf(T item)
        {

            for (int i = 0; i < Capacity; i++)
            {
                if (ArrayGeneric[i].Equals(item))
                    return i;
            }
            return -1;



        }

        #region [Helper Functions]

        public bool isFull()
        {
            if (Capacity > CurrentItem)
            {
                return false;
            }
            else
                return true;
        }
        public void DisplayAll()
        {
            for (int i = 0; i < ArrayGeneric.Length; i++)
            {
                Console.Write(ArrayGeneric[i] + " ");
            }
            Console.WriteLine();
        }
        public void Display(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write(ArrayGeneric[i] + " ");
            }
            Console.WriteLine();
        }
        public int Length()
        {
            return ArrayGeneric.Length;
        }

        #endregion
    }
}

