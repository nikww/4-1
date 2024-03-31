using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public interface IOne<T>
    {
        void CreateWithFixLen(int len);

        void CreateWithDefLen();

        void PushBack(T elem);

        void Erase(T elem);

        void Sort();

        int NumberElems();

        void Reverse();

        T[] Subarray(int index, int cnt);

        bool Exist(T elem);

        T GetMax();

        T GetMin();

        int CountWithCond(Predicate<T> cond);

        bool HaveOne(Predicate<T> cond);

        T ReturnFirst(Predicate<T> cond);

        bool IsAll(Predicate<T> cond);

        TResult[] InOtherType<TResult>(Func<T, TResult> conv);

        void DoForAll(Action<T> act);

        T[] GetElementsByType<TResult>();

        T[] GetElementsByCond(Predicate<T> cond);

        TResult GetMaxByProj<TResult>(Func<T, TResult> conv);

        TResult GetMinByProj<TResult>(Func<T, TResult> conv);

        void ForEach(Action<T> act);
    }
}
