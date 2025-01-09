using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class ArrSort
    {
        private int[] arr;
        private int[] arr1;
        private int len;
        public ArrSort()
        {
            this.len = 10;
            this.arr = new int[this.len];
            this.arr1 = new int[this.len];
        }
        public ArrSort(int len)
        {
            this.len = len;
            this.arr = new int[this.len];
        }
        public int len1
        {
            get { return this.len; }
        }
        public int[] array
        {
            get { return this.arr; }
        }

        public int[] RandomArray()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = rnd.Next(-100, 100);
            }
            return this.arr;
        }
        public void OutputArray()
        {
            foreach (int i in this.arr)
                Console.WriteLine("{0}   ", i);
            Console.WriteLine("");
        }
        public void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public int[] BubbleSort()
        {
            var length = this.arr.Length;
            for (var i = 1; i < length; i++)
            {
                for (var j = 0; j < length - i; j++)
                {
                    if (this.arr[j] > this.arr[j + 1])
                    {
                        Swap(ref this.arr[j], ref this.arr[j + 1]);
                    }
                }
            }
            return this.arr;
        }
        public int[] ShakerSort()
        {
            for (var i = 0; i < this.arr1.Length / 2; i++)
            {
                var swapFlag = false;
                for (var j = i; j < this.arr1.Length - i - 1; j++)
                {
                    if (this.arr1[j] > this.arr1[j + 1])
                    {
                        Swap(ref this.arr1[j], ref this.arr1[j + 1]);
                        swapFlag = true;
                    }
                }
                for (var j = this.arr1.Length - 2 - i; j > i; j--)
                {
                    if (this.arr1[j - 1] > this.arr1[j])
                    {
                        Swap(ref this.arr1[j - 1], ref this.arr1[j]);
                        swapFlag = true;
                    }
                }
                if (!swapFlag)
                {
                    break;
                }
            }

            return this.arr1;
        }
        public int[] ArrClone()
        {
            int[] arr1 = new int[this.len];
            for (int i = 0; i < this.len; i++)
            {
                arr1[i] = this.arr[i];
            }
            return arr1;
        }
        public void Sortings()
        {
            int n;
            long res1;
            long res2;
            int[] arr = new int[this.len];
            int[] arr1 = new int[this.len];
            Stopwatch timer = new Stopwatch();
            this.arr=RandomArray();
            OutputArray();
            this.arr1 = ArrClone();
            timer.Start();
            BubbleSort();
            timer.Stop();
            res1 = timer.ElapsedTicks;
            OutputArray();
            Console.WriteLine("Время выполнения сортировки: " + res1);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            timer.Reset();
            timer.Start();
            ShakerSort();
            timer.Stop();
            res2 = timer.ElapsedTicks;
            OutputArray();
            Console.WriteLine("Время выполнения сортировки: " + res2);
            if (res1 < res2)
            {
                Console.WriteLine("Сортировка пузырьком быстрее");
            }
            else if (res1 == res2)
            {
                Console.WriteLine("Сортировки выполняются за одно и то же время");
            }
            else
            {
                Console.WriteLine("Сортировка перемешиванием быстрее");
            }
            RoAVCheck.Continue();
        }
    }
}
