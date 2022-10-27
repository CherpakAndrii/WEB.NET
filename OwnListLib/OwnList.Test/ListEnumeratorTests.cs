namespace OwnList.Test;

public class ListEnumeratorTests
{
    [Test]
    public void EnumeratorOfEmptyListCantMoveNext()
    {
        OwnList<int> list = new OwnList<int>();
        var enumerator = list.GetEnumerator();

        bool canMove = enumerator.MoveNext();
        enumerator.Dispose();
        
        Assert.AreEqual(false, canMove);
    }
    
    [Test]
    public void EnumeratorOfNotEmptyListCanMoveNext()
    {
        OwnList<int> list = new OwnList<int>(){5, 3, 5};
        var enumerator = list.GetEnumerator();

        bool canMove = enumerator.MoveNext();
        enumerator.Dispose();
        
        Assert.AreEqual(true, canMove);
    }
    
    [Test]
    public void EnumeratorAfterCreationPointsAtNodeBeforeFirst()
    {
        OwnList<int> list = new OwnList<int>() { 5, 6, 7, 8, 0 };
        var enumerator = list.GetEnumerator();
        
        if (!enumerator.MoveNext()) Assert.Fail();
        var res = enumerator.Current;
        enumerator.Dispose();

        Assert.AreEqual(5, res);
    }
    
    [Test]  
    public void EnumeratorAtLastPositionCantMoveNext()
    {
        OwnList<int> list = new OwnList<int>() { 5, 6, 7};
        var enumerator = list.GetEnumerator();
        
        for (int i = 0; i < 3; i++) if (!enumerator.MoveNext()) Assert.Fail();
        bool canMove = enumerator.MoveNext();
        enumerator.Dispose();

        Assert.AreEqual(false, canMove);
    }

    [Test]
    public void EnumeratorResetNotImplemented()
    {
        OwnList<int> list = new OwnList<int>() { 5, 6, 7};
        var enumerator = list.GetEnumerator();
        
        var f = () =>
        {
            enumerator.Reset();
            enumerator.Dispose();
        };
        
        Assert.Catch(typeof(System.NotImplementedException), new TestDelegate(f));
    }
}