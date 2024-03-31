using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class One<T> : IOne<T>
    {
        private T[] array;
        private const int length_default = 3;
        private int length = 0, length_full = 0;
        Comparer<T> comp = Comparer<T>.Default;

        public void array_output()
        {
            for (int i = 0; i < length_full; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public void CreateWithFixLen(int len)
        {
            if (len < 0)
            {
                throw new Exception("Отрицательная длина");
            }
            else
            {
                length = len;
                array = new T[len];
            }
        }

        public void CreateWithDefLen()
        {
            CreateWithFixLen(length_default);
        }

        public void PushBack(T elem)
        {
            if (length_full >= length)
            {
                length = 2 * length + 1;
                T[] cur_array = new T[length];
                array.CopyTo(cur_array, 0);
                array = cur_array;
            }
            array[length_full] = elem;
            ++length_full;
        }

        public void Erase(T elem)
        {
            int index = -1;
            for (int i = 0; i < length_full; ++i)
            {
                if(array[i].Equals(elem))
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                throw new Exception("Такого элемента в массиве нет");
            }
            else
            {
                Array.Copy(array, index + 1, array, index, length_full - index);
                --length_full;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < length_full; ++i)
            {
                for (int j = 0; j < length_full; ++j) 
                {
                    if (comp.Compare(array[i], array[j]) < 0)
                    {
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
            }
        }

        public int NumberElems()
        {
            return length_full;
        }

        public void Reverse()
        {
            for (int i = 0; i < length_full; ++i)
            {
                array[i] = array[length_full - i - 1];
            }
        }

        public T[] Subarray(int index, int cnt)
        {
            if (index >= length_full)
            {
                throw new Exception("Нет элементов по такому индексу");
            }
            else
            {
                T[] cur_array = new T[cnt];
                for (int i = index; i < length_full; i++)
                {
                    cur_array[i - index] = array[i];
                }

                return cur_array;
            }
        }

        public bool Exist(T elem)
        {
            for (int i = 0; i < length_full; i++)
            {
                if (array[i].Equals(elem))
                {
                    return true;
                }
            }
            return false;
        }

        public T GetMax()
        {
            T maximum = array[0];
            for (int i = 1; i < length_full; i++)
            {
                if (comp.Compare(array[i], maximum) > 0)
                {
                    maximum = array[i];
                }
            }

            return maximum;
        }

        public T GetMin()
        {
            T minimum = array[0];
            for (int i = 1; i < length_full; i++)
            {
                if (comp.Compare(array[i], minimum) < 0)
                {
                    minimum = array[i];
                }
            }

            return minimum;
        }

        public int CountWithCond(Predicate<T> cond)
        {
            if (cond == null)
            {
                throw new Exception("Пустое условие");
            }

            int cnt = 0;
            for (int i = 0; i < length_full; ++i)
            {
                if (cond(array[i]))
                {
                    ++cnt;
                }
            }
            return cnt;
        }

        public bool HaveOne(Predicate<T> cond)
        {
            if (cond == null)
            {
                throw new Exception("Пустое условие");
            }

            for (int i = 0; i < length_full; ++i)
            {
                if (cond(array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public T ReturnFirst(Predicate<T> cond)
        {
            if (cond == null)
            {
                throw new Exception("Пустое условие");
            }

            T ans = default(T);
            for (int i = 0; i < length_full; ++i)
            {
                if (cond(array[i]))
                {
                    ans = array[i];
                    break;
                }
            }
            
            if(ans.Equals(default(T)))
            {
                throw new Exception("Элемента, удовлетворяющего такому условию, нет");
            }
            else
            {
                return ans;
            }
        }

        public bool IsAll(Predicate<T> cond)
        {
            if (cond == null)
            {
                throw new Exception("Пустое условие");
            }

            bool ans = true;
            for (int i = 0; i < length_full; ++i)
            {
                if (!cond(array[i]))
                {
                    ans = false;
                }
            }
            return ans;
        }

        public TResult[] InOtherType<TResult>(Func<T, TResult> conv)
        {
            if (conv == null)
            {
                throw new Exception("Пустое условие");
            }

            TResult[] new_array = new TResult[length_full];
            for (int i = 0; i < length_full; i++)
            {
                new_array[i] = conv(array[i]);
            }
            return new_array;
        }

        public void DoForAll(Action<T> act)
        {
            if (act == null)
            {
                throw new Exception("Пустое условие");
            }
            
            for (int i = 0; i < length_full; ++i)
            {
                act(array[i]);
            }
        }

        public T[] GetElementsByType<TResult>()
        {
            T[] new_array = new T[length_full];
            int j = 0;
            
            for (int i = 0; i < length_full; i++)
            {
                if (array[i].GetType() == typeof(TResult))
                {
                    new_array[j] = array[i];
                    ++j;
                }
            }

            T[] temp_array = new T[j];
            new_array.CopyTo(temp_array, 0);
            return temp_array;
        }

        public T[] GetElementsByCond(Predicate<T> cond)
        {
            if (cond == null)
            {
                throw new Exception("Пустое условие");
            }

            T[] new_array = new T[length_full];
            int j = 0;
            for (int i = 0; i < length_full; i++)
            {
                if (cond(array[i]))
                {
                    new_array[j] = array[i];
                    ++j;
                }
            }

            T[] temp_array = new T[j];
            new_array.CopyTo(temp_array, 0);
            return temp_array;
        }

        public TResult GetMaxByProj<TResult>(Func<T, TResult> conv)
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            if (conv == null)
            {
                throw new Exception("Пустое условие");
            }

            TResult maximum = conv(array[0]);
            for (int i = 1; i < length_full; ++i)
            {
                if (comparer.Compare(conv(array[i]), maximum) > 0)
                {
                    maximum = conv(array[i]);
                }
            }

            return maximum;
        }

        public TResult GetMinByProj<TResult>(Func<T, TResult> conv)
        {
            Comparer<TResult> comparer = Comparer<TResult>.Default;
            if (conv == null)
            {
                throw new Exception("Пустое условие");
            }

            TResult minimum = conv(array[0]);
            for (int i = 1; i < length_full; ++i)
            {
                if (comparer.Compare(conv(array[i]), minimum) < 0)
                {
                    minimum = conv(array[i]);
                }
            }

            return minimum;
        }

        public void ForEach(Action<T> act)
        {
            if (act == null)
            {
                throw new Exception("Пустое условие");
            }

            
            for (int i = 0; i < length_full; ++i)
            {
                act(array[i]);                      // На самом деле, то же самое, что и DoForAll()
            }
        }
    }
}
