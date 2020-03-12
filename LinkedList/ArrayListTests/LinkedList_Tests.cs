using NUnit.Framework;

namespace LinkedList.Tests
{
    public class LinkedList_Tests
    {

        [Test]
        public void AddFirst_Test()
        {
            LinkedList list1 = new LinkedList();
            list1.AddFirst(5);
            int actual = list1.GetFirst();
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 5, 4, 3, 6 }, new int[] { 5, 4, 3, 6 })]
        public void AddValsLast_Test(int[] vals, int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(vals);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AddLast_Test()
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            int actual = list1.GetLast();
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetSize_Test()
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            int actual = list1.GetSize();
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
        // деление всех элементов строки на значение первого аргумента
        // вычитание строки из следующей строки n раз
        // вывести ответ

        // в классе лижит только один метод, который содержит в себе приватные методы реализации

        [TestCase(0, 5)]
        [TestCase(1, 4)]
        [TestCase(2, 3)]
        [TestCase(3, 6)]
        public void GetByIdx_Test(int idx, int expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            int actual = list1.Get(idx);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToArray_Test()
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            int[] actual = list1.ToArray();
            int[] expected = new int[] { 5, 4, 3, 6 };
            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, 5)]
        [TestCase(1, 4)]
        [TestCase(2, 3)]
        [TestCase(-1, 7)]
        public void Contains_Test( int expected, int val)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            int actual = list1.Contains(val);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(0, 10, new int[] { 10, 5, 4, 3, 6 })]
        [TestCase(2, 10, new int[] { 5, 4, 10, 3, 6 })]
        [TestCase(3, 10, new int[] { 5, 4, 3, 10, 6 })]
        public void AddAt_Test(int idx, int val, int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.AddAt(idx, val);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, new int[] { 10, 4 }, new int[] { 5, 10, 4, 4, 3, 6 })]
        [TestCase(2, new int[] { 10, 4 }, new int[] { 5, 4, 10, 4, 3, 6 })]
        [TestCase(3, new int[] { 10, 4 }, new int[] { 5, 4, 3, 10, 4, 6 })]
        public void AddArrayAt_Test(int idx, int[] vals, int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.AddAt(idx, vals);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 10, 4 }, new int[] { 10, 4, 5, 4, 3, 6 })]
        public void AddArrayFirst_Test(int[] vals, int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.AddFirst(vals);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void Set_Test(int idx, int val)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.Set(idx, val);
            int actual = list1.Get(idx);
            Assert.AreEqual(val, actual);
        }



        [TestCase(new int[] { 6, 3, 4, 5 })]
        public void Reverse_Test(int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.Reverse();
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 4, 3, 2, 1 })]
        public void Reverse_Test1(int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3);
            list1.AddLast(4);
            list1.Reverse1();
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }




        [TestCase(new int[] { 4, 3, 6 })]
        public void RemoveFirst_Test(int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.RemoveFirst();
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] {5, 4, 3})]
        public void RemoveLast_Test(int[] expected)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.RemoveLast();
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 5, 4, 3 }, 3)]
        [TestCase(new int[] { 5, 4, 6 }, 2)]
        [TestCase(new int[] { 5, 3, 6 }, 1)]
        public void RemoveAt_Test(int[] expected, int idx)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.RemoveAt(idx);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 4, 3 }, 6)]
        [TestCase(new int[] { 5, 4, 6 }, 3)]
        public void RemoveAll_Test(int[] expected, int val)
        {
            LinkedList list1 = new LinkedList();
            list1.AddLast(5);
            list1.AddLast(4);
            list1.AddLast(3);
            list1.AddLast(6);
            list1.RemoveAll(val);
            int[] actual = list1.ToArray();
            Assert.AreEqual(expected, actual);
        }
    }
}
