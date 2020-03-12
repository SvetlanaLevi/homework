using NUnit.Framework;

namespace ArrayList.Tests
{
    public class ArrayList_Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(new int[4] { 1, 2, 3, 4 })]
        public void GetArray_Test(int[] array)
        {
            ArrayList list = new ArrayList(array);
            int[] actual = list.GetArray();
            int[] expected = array;
            CollectionAssert.AreEqual(actual, expected);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, 2, 3)]
        [TestCase(new int[4] { 1, 2, 3, 4 }, 0, 1)]
        [TestCase(new int[4] { 1, 2, 3, 4 }, 9, null)]
        public void Get_Test(int[] array, int idx, int? expected)
        {
            ArrayList list = new ArrayList(array);
            int[] arr = list.GetArray();
            int? actual = list.Get(idx);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[7] { 1, 2, 3, 4, 5, 0, 0}, 5)]
        public void Add_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.Add(val);
            int[] actual = list.GetArray();
            CollectionAssert.AreEqual(actual, expected);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[7] { 1, 1, 2, 3, 4, 0, 0 }, 0, 1)]
        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[7] { 1, 2, 1, 3, 4, 0, 0 }, 2, 1)]
        public void Add_at_index_Test(int[] array, int[] expected, int idx, int val)
        {
            ArrayList list = new ArrayList(array);
            list.Add(idx, val);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 4 }, new int[13] { 1, 2, 3, 4, 1, 2, 3, 4, 0, 0, 0, 0, 0 })]
        public void AddAll_Test(int[] array, int[] newarray, int[] expected)
        {
            ArrayList list = new ArrayList(array);
            list.AddAll(newarray);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 4 }, new int[13] { 1, 2, 1, 2, 3, 4, 3, 4, 0, 0, 0, 0, 0 }, 2)]
        public void AddAll_at_index_Test(int[] array, int[] newarray, int[] expected, int idx)
        {
            ArrayList list = new ArrayList(array);
            list.AddAll(idx, newarray);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, 5, 5)]
        public void Size_Test(int[] array, int expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.Add(val);
            int actual = list.Size();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 3, 4 }, new int[13] { 1, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
         public void ExpandArray_with_new_array_Test(int[] array, int[] newarray, int[] expected )
         {
             ArrayList list = new ArrayList(array);
             list.ExpandArray(newarray);
             int[] actual = list.GetArray();
             Assert.AreEqual(actual, expected);
         }

        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[7] { 1, 2, 3, 4, 0, 0, 0 })]
        public void ExpandArray_Test(int[] array, int[] expected)
        {
            ArrayList list = new ArrayList(array);
            list.ExpandArray();
            int[] actual = list.GetArray();
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 3, 4, 0 }, 1)]
        public void RemoveIdx_Test(int[] array, int[] expected, int idx)
        {
            ArrayList list = new ArrayList(array);
            list.RemoveIdx(idx);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }
         

        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 3, 4, 0 }, 2)]
        public void RemoveVal_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.RemoveVal(val);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, 2, 3)]
        public void IndexOf_Test(int[] array, int expected, int val)
        {
            ArrayList list = new ArrayList(array);
            int? actual = list.IndexOf(val);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 2 }, new int[2] { 1, 3 }, 2)]
        public void Search_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            int[] actual = list.Search(val);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 2 }, new int[4] { 1, 3, 0, 0 }, 2)]
        [TestCase(new int[4] { 1, 2, 2, 2 }, new int[4] { 1, 0, 0, 0 }, 2)]
        [TestCase(new int[8] { 1, 2, 9, 2, 1, 9, 1, 9 }, new int[8] { 1, 2, 2, 1, 1, 0, 0, 0}, 9)]
        public void RemoveAll_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.RemoveAll(val);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[4] { 1, 2, 3, 2 }, new int[4] { 1, 3, 0, 0 }, 2)]
        [TestCase(new int[4] { 1, 2, 2, 2 }, new int[4] { 1, 0, 0, 0 }, 2)]
        [TestCase(new int[8] { 1, 2, 9, 2, 1, 9, 1, 9 }, new int[8] { 1, 2, 2, 1, 1, 0, 0, 0 }, 9)]
        public void RemoveAll2_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.RemoveAll2(val);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[4] { 1, 2, 3, 2 }, new int[4] { 1, 3, 0, 0 }, 2)]
        [TestCase(new int[4] { 1, 2, 2, 2 }, new int[4] { 1, 0, 0, 0 }, 2)]
        [TestCase(new int[8] { 1, 2, 9, 2, 1, 9, 1, 9 }, new int[8] { 1, 2, 2, 1, 1, 0, 0, 0 }, 9)]
        public void RemoveAll3_Test(int[] array, int[] expected, int val)
        {
            ArrayList list = new ArrayList(array);
            list.RemoveAll3(val);
            int[] actual = list.GetArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[4] { 1, 2, 3, 2 }, 2, true)]
        [TestCase(new int[4] { 1, 2, 3, 2 }, 5, false)]
        public void Contains_Test(int[] array, int val, bool expected)
        {
            ArrayList list = new ArrayList(array);
            bool actual = list.Contains(val);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[4] { 1, 2, 3, 4 }, new int[4] { 1, 2, 5, 4 }, 2, 5)]
        public void Set_Test(int[] array, int[] expected, int idx, int val)
        {
            ArrayList list = new ArrayList(array);
            list.Set(idx, val);
            int[] actual = list.GetArray();
            CollectionAssert.AreEqual(actual, expected);
        }

    }
}