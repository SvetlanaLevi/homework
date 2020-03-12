using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    public class ArrayList
    {
        private int[] array;
        private int reallenght;

        public ArrayList()
        {
            array = new int[10];
            reallenght = 0;
        }

        public ArrayList(int[] array)
        {
            this.array = array;
            reallenght = array.Length;
        }

        public int[] GetArray()
        {
            return array;
        }

        public int? Get(int idx)  // возвращает элемент массива по индексу
        {
            if (idx < reallenght)
            {
                return array[idx];
            }

            return null;
        }

        public void ExpandArray() // расширяет массив
        {
            int[] temp = new int[(array.Length * 3 / 2) + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        public void ExpandArray(int[] array) // расширяет массив для записи нового массива
        {
            int newlenght = ((array.Length + this.array.Length) * 3 / 2) + 1;
            int[] temp = new int[newlenght];
            for (int i = 0; i < this.array.Length; i++)
            {
                temp[i] = this.array[i];
            }
            this.array = temp;
        }

        public void Add(int val) // добавляет элемент в конец массива
        {
           
            if (reallenght == this.array.Length)
            {
                ExpandArray();
            }
            this.array[reallenght] = val;
            reallenght++;

        }

        public void Add(int idx, int val) // добавляет в массив элемент под индексом и сдвигает массив
        {
            if (idx >= reallenght)
            {
                // выдать ошибку!!!!!!!!!
            }

            if (reallenght == this.array.Length)
            {
                ExpandArray();
            }

            for (int i = reallenght-1; i>=idx; i--)
            {
                this.array[i+1] = this.array[i];
            }
            this.array[idx] = val;
            reallenght++;
        }

        public void AddAll(int[] vals) // добавляет элементы в конец массива 
        {
            ExpandArray(vals);
            for(int i = 0; i < vals.Length; i++)
            {
                Add(vals[i]);
            }
        }

        public void AddAll(int index, int[] vals) // добавляет элементы в место по индексу и сдвигает массив 
        {
            ExpandArray(vals);
            for (int i = 0; i < vals.Length; i++)
            {
                Add(index, vals[i]);
                index++;
            }
        }

        public void  RemoveIdx(int idx) // удаляет элемент массива по индексу и сдвигает массив
        {
            if (idx >= reallenght)
            {
                // выдать ошибку!!!!!!!!!
            }

            for (int i = idx; i < reallenght-1; i++)
            {
                this.array[i] = this.array[i+1];
            }
            this.array[reallenght - 1] = 0;
            reallenght--;
  //
  //         if (this.array.Length > ((array.Length + this.array.Length) * 3 / 2) + 1)
  //         {
  //             int newlenght = ((array.Length + this.array.Length) * 3 / 2) + 1;
  //             int[] temp = new int[newlenght];
  //             for (int i = 0; i < this.array.Length; i++)
  //             {
  //                 temp[i] = this.array[i];
  //             }
  //             this.array = temp;
  //         }

        }

        public void RemoveVal(int val)  // удаляет первый элемент массива с передаваемым значением и сдвигает массив
        {
            int? idx = IndexOf(val);
           
            for (int i = (int)idx; i < reallenght - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[reallenght - 1] = 0;
            reallenght--;

        }

        public void RemoveAll(int val)  // удаляет все элементы массива с передаваемым значением и сдвигает массив
        {
            int[] indexArray = Search(val);
            for (int i = indexArray.Length-1; i >= 0; i--)
            {
                RemoveIdx(indexArray[i]);
            }

        }

        public void RemoveAll2(int val)  // удаляет все элементы массива с передаваемым значением и сдвигает массив
        {
            int[] temp = new int[reallenght];

            int k = 0;

            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] != val)
                {
                    temp[i - k] = this.array[i];
                }
                else
                {
                    k++;
                }
            }

            this.array = temp;
            reallenght -= k;
        }

        public void RemoveAll3(int val)  // удаляет все элементы массива с передаваемым значением и сдвигает массив
        {
            int[] temp = new int[reallenght];

            int k = 0;

            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] != val)
                {
                    temp[k] = this.array[i];
                    k++;
                }
            }

            this.array = temp;
            reallenght = k;
        }

        public void Set(int idx, int val)  // заменяет элемент массива по индексу
        {
            if (idx >= reallenght)
            {
                // выдать ошибку!!!!!!!!!

            }

            this.array[idx] = val;

        }

        public int Size()  // возвращает фактический размер массива
        {
            return reallenght;
        }

        public bool Contains(int val)  // проверяет наличие элемента в массиве
        {
            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] == val)
                {
                    return true;
                }
            }

            return false;
        }

        public int? IndexOf(int val) // возвращает индекс первого элемента с переданным значением
        {
            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] == val)
                {
                    return i;
                } 
            }
            // выдать ошибку!!!!!!!!!
            return null;
        }

        public int[] Search(int val)  // возвращает все индексы элемента
        {
            int indexArrayLenght = 0;

            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] == val)
                {
                    indexArrayLenght++;
                }
            }

            if (indexArrayLenght == 0)
            {

                // выдать ошибку!!!!!!!!!
                return null;
            }

            int[] indexArray = new int[indexArrayLenght];
            int k = 0;

            for (int i = 0; i < reallenght; i++)
            {
                if (this.array[i] == val)
                {
                    indexArray[k] = i;
                    k++;
                }
            }

            return indexArray;

        }

    }
}
