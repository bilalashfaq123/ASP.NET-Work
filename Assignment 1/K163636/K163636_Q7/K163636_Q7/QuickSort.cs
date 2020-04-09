using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q7
{
    unsafe public class QuickSort
    {
        public void quickSort(int[] arr, int less, int high)
        {
            if (less < high)
            {
                int s = Sort(arr, less, high);
                quickSort(arr, less, s - 1);
                quickSort(arr, s + 1, high);
            }
        }

        private int Sort(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    #region Swapping
                    fixed (int* a = &arr[i])
                    {
                        fixed (int* b = &arr[j])
                        {
                            int t = *a;
                            *a = *b;
                            *b = t;
                        }
                    }
                    #endregion
                }
            }

            #region Swapping
            fixed (int* a = &arr[i + 1])
            {
                fixed (int* b = &arr[high])
                {
                    int t = *a;
                    *a = *b;
                    *b = t;
                }
            }
            #endregion
            return (i + 1);
        }

    }
}