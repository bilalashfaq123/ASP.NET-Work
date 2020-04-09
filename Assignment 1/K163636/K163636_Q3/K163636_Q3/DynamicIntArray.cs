using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q3
{
    public sealed class DynamicIntArray
    {
        private int Size = 0;
        private int Capacity;
        private int[] ArrayInt;
        private static int CurrentItem = 0;
        public DynamicIntArray()
        {
            this.Capacity = 10;
            ArrayInt = new int[Capacity];
            Console.WriteLine("Array Created with size " + Capacity);
        }
        public DynamicIntArray(int size)
        {
            this.Capacity = size;
            ArrayInt = new int[Capacity];
            Console.WriteLine("Array Created with size " + Capacity);
        }
        public void AddInt(int element)
        {
            if (!isFull())
            {
                //Console.WriteLine("Inserting Element");
                ArrayInt[CurrentItem] = element;
                CurrentItem++;
            }
            else
            {
                //Console.WriteLine("Resizing And Inserting Element");
                Array.Resize(ref ArrayInt, ArrayInt.Length + 1);
                ArrayInt[CurrentItem] = element;
                Capacity++;
                CurrentItem++;
            }
        }

        public int getInt(int i)
        {
            return ArrayInt[i];
        }
        public int indexOf(int item)
        {

            for (int i = 0; i < Capacity; i++)
            {
                if (ArrayInt[i] == item)
                    return i;
            }
            return -1;



        }

        public long getSum()
        {
            return ArrayInt.Sum();
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
            for (int i = 0; i < ArrayInt.Length; i++)
            {
                Console.Write(ArrayInt[i] + " ");
            }
            Console.WriteLine();
        }
        public void Display(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write(ArrayInt[i] + " ");
            }
            Console.WriteLine();
        }
        public int Length()
        {
            return ArrayInt.Length;
        }

        #endregion
    }
}
