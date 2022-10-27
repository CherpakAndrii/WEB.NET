namespace OwnList.Test;

public class OwnListTests
{
    [Test]
    public void CopyToArray()
    {
        OwnList<int> list = new OwnList<int>{5, 4, 3, 2, 125};
        int[] arr = new int[8];
        
        list.CopyTo(arr, 3);

        CollectionAssert.AreEqual(new int[]{0, 0, 0, 5, 4, 3, 2, 125}, arr);
    }
    
    [Test]
    public void CopyToArraySmallerThanNeeded__IndexOutOfRangeExceptionThrowed()
    {
        OwnList<int> list = new OwnList<int>{5, 4, 3, 2, 125};
        int[] arr = new int[3];
        
        var copyTo = () => list.CopyTo(arr, 0);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(copyTo));    
    }
    
    [Test]
    public void AddToEmpty()
    {
        OwnList<int> list = new OwnList<int>();
        
        list.Add(125);

        CollectionAssert.AreEqual(new OwnList<int>(){125}, list);
    }
    
    [Test]
    public void AddToNotEmpty__LengthIncremented()
    {
        OwnList<int> list = new OwnList<int>(){5, 8};
        
        list.Add(125);

        Assert.AreEqual(3, list.Count);
    }
    
    [Test]
    public void AddToNotEmpty__ValueAddedOnNeededPosition()
    {
        OwnList<int> list = new OwnList<int>(){5, 8};
        int[] arr = new int[4];
        
        list.Add(125);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[]{5, 8, 125, 0}, arr);
    }
    
    [Test]
    public void ClearEmptyList__LengthIs0()
    {
        OwnList<int> list = new OwnList<int>();
        
        list.Clear();

        Assert.AreEqual(0, list.Count);
    }
    
    [Test]
    public void ClearNotEmptyList__LengthIs0()
    {
        OwnList<int> list = new OwnList<int>(){5, 8, 125};
        
        list.Clear();

        Assert.AreEqual(0, list.Count);
    }
    
    [Test]
    public void ContainsForEmptyList__FalseReturned()
    {
        OwnList<int> list = new OwnList<int>();
        
        bool res = list.Contains(5);

        Assert.AreEqual(false, res);
    }
    
    [Test]
    public void ContainsForListWithoutNeededValue__FalseReturned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125};
        
        bool res = list.Contains(5);

        Assert.AreEqual(false, res);
    }
    
    [Test]
    public void ContainsForListWithNeededValue__TrueReturned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        bool res = list.Contains(5);

        Assert.AreEqual(true, res);
    }
    
    [Test]
    public void RemoveFromEmptyList__FalseReturned()
    {
        OwnList<int> list = new OwnList<int>();
        
        bool res = list.Remove(5);

        Assert.AreEqual(false, res);
    }
    
    [Test]
    public void RemoveFromListWithoutNeededValue__FalseReturned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125};
        
        bool res = list.Remove(5);

        Assert.AreEqual(false, res);
    }
    
    [Test]
    public void RemoveFromListWithoutNeededValue__NothingRemoved()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125};
        int[] arr = new int[4];
        
        list.Remove(5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[]{1, 8, 125, 0}, arr);
    }
    
    [Test]
    public void RemoveFromListWithNeededValue__TrueReturned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        bool res = list.Remove(5);

        Assert.AreEqual(true, res);
    }
    
    [Test]
    public void RemoveFromІштпдуУдуьутеListWithNeededValue__TrueReturned()
    {
        OwnList<int> list = new OwnList<int>(){5};
        
        bool res = list.Remove(5);

        Assert.AreEqual(true, res);
    }
    
    [Test]
    public void RemoveFromListWithNeededValue__ValueRemoved()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        bool res = list.Remove(5);

        Assert.AreEqual(true, res);
    }
    
    [Test]
    public void IndexOfInEmptyList__Minus1Returned()
    {
        OwnList<int> list = new OwnList<int>();
        
        int index = list.IndexOf(125);

        Assert.AreEqual(-1, index);
    }
    
    [Test]
    public void IndexOfInListWithoutNeededValue__Minus1Returned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 100, 5, 16};
        
        int index = list.IndexOf(125);

        Assert.AreEqual(-1, index);
    }
    
    [Test]
    public void IndexOfInListWithNeededValue__CorrectIndexReturned()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        int index = list.IndexOf(125);

        Assert.AreEqual(2, index);
    }
    
    [Test]
    public void IndexOfInListWithNeededValue__CorrectIndexReturned2()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        int index = list.IndexOf(1);

        Assert.AreEqual(0, index);
    }
    
    [Test]
    public void IndexOfInListWithNeededValue__CorrectIndexReturned3()
    {
        OwnList<int> list = new OwnList<int>(){1, 8, 125, 5, 16};
        
        int index = list.IndexOf(16);

        Assert.AreEqual(4, index);
    }

    [Test]
    public void InsertIntoEmptyListOn0Position()
    {
        OwnList<int> list = new OwnList<int>();
        int[] arr = new int[3];
        
        list.Insert(0, 5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 5, 0, 0 }, arr);
    }
    
    [Test]
    public void InsertIntoEmptyListOn1Position__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>();
        
        var insert = () => list.Insert(1, 5);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(insert));
    }
    
    [Test]
    public void InsertIntoEmptyListOnMinus1Position__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>();
        
        var insert = () => list.Insert(-1, 5);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(insert));
    }
    
    [Test]
    public void InsertIntoNotEmptyListOn0Position()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.Insert(0, 5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 5, 1, 2, 3, 8, 0 }, arr);
    }
    
    [Test]
    public void InsertIntoNotEmptyListOnLastPosition()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.Insert(3, 5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 5, 8, 0 }, arr);
    }
    
    [Test]
    public void InsertIntoNotEmptyListOnMiddlePosition()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.Insert(2, 5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 1, 2, 5, 3, 8, 0 }, arr);
    }
    
    [Test]
    public void InsertIntoNotEmptyListOnNextPosition()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.Insert(4, 5);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 8, 5, 0 }, arr);
    }
    
    [Test]
    public void InsertIntoNotEmptyListOnMinus1Position__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5};
        
        var insert = () => list.Insert(-1, 5);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(insert));
    }
    
    [Test]
    public void InsertIntoNotEmptyListOnBiggerThanAllowedPosition__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5};
        
        var insert = () => list.Insert(5, 5);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(insert));
    }

    [Test]
    public void RemoveAtFromEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>();
        
        var remove = () => list.RemoveAt(0);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(remove));
    }
    
    [Test]
    public void RemoveAtMinus1FromNotEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5};
        
        var remove = () => list.RemoveAt(-1);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(remove));
    }
    
    [Test]
    public void RemoveAtBiggerThanAllowedFromNotEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5};
        
        var remove = () => list.RemoveAt(5);

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(remove));
    }
    
    [Test]
    public void RemoveAt0FromNotEmptyList__CorrectResult()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.RemoveAt(0);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 2, 3, 8, 0, 0, 0 }, arr);
    }
    
    [Test]
    public void RemoveAtLastFromNotEmptyList__CorrectResult()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.RemoveAt(3);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 0, 0, 0 }, arr);
    }
    
    [Test]
    public void RemoveAtCentralFromNotEmptyList__CorrectResult()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8};
        int[] arr = new int[6];
        
        list.RemoveAt(2);
        list.CopyTo(arr, 0);

        CollectionAssert.AreEqual(new int[] { 1, 2, 8, 0, 0, 0 }, arr);
    }
    
    
    
    [Test]
    public void GetAtBiggerThanAllowedFromNotEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5, 125};
        
        var getFunc = () =>
        {
            var a = list[5];
        };

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(getFunc));
    }
    
    [Test]
    public void GetAtLessThanAllowedFromNotEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 5, 125};
        
        var getFunc = () =>
        {
            var a =  list[-6];
        };

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(getFunc));
    }
    
    [Test]
    public void GetFromEmpty__IndexOutOfRangeExceptionThrow()
    {
        OwnList<int> list = new OwnList<int>();
        
        var getFunc = () =>
        {
            var a = list[0];
        };

        Assert.Catch(typeof(IndexOutOfRangeException), new TestDelegate(getFunc));
    }

    [Test]
    public void GetAt0FromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        int a = list[0];
        
        Assert.AreEqual(1, a);
    }
    
    [Test]
    public void GetAtMinus1FromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        int a = list[-1];
        
        Assert.AreEqual(965, a);
    }
    
    [Test]
    public void GetAtLastFromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        int a = list[5];
        
        Assert.AreEqual(965, a);
    }
    
    [Test]
    public void GetAtMinusLastFromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        int a = list[-6];
        
        Assert.AreEqual(1, a);
    }
    
    [Test]
    public void GetAtCenterFromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        int a = list[3];
        
        Assert.AreEqual(4, a);
    }
    
    [Test]
    public void SetAtCenterFromNotEmptyList()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};

        list[3] = 2;
        
        Assert.AreEqual(2, list[3]);
    }

    [Test]
    public void ForeachInEmpty__CorrectWork()
    {
        OwnList<int> list = new OwnList<int>();
        List<int> l = new List<int>();

        foreach (var element in list)
        {
            l.Add(element);
        }

        CollectionAssert.AreEqual(new List<int>(), l);
    }
    
    [Test]
    public void ForeachInNotEmpty__CorrectWork()
    {
        OwnList<int> list = new OwnList<int>(){1, 2, 3, 8, 125};
        List<int> l = new List<int>();

        foreach (var element in list)
        {
            l.Add(element);
        }

        CollectionAssert.AreEqual(new List<int>(){1, 2, 3, 8, 125}, l);
    }

    [Test]
    public void MakeReadonly__AsExpected()
    {
        OwnList<int> list = new OwnList<int>(){1, 5, 9, 4, 125, 965};
        list.MakeReadonly();

        var testAction = () =>
        {
            list[3] = 2;
        };

        Assert.Catch(typeof(FieldAccessException), new TestDelegate(testAction));
    }
}