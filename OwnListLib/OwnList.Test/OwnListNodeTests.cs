namespace OwnList.Test;

public class OwnListNodeTests
{
    [Test]
    public void UsingIndexer1_NextNodeReturned()
    {
        OwnList<int> list = new OwnList<int> { 5, 8 };
        OwnList<int>.Node first = list._head;

        int nextNodeData = first[1].Data;
        
        Assert.AreEqual(8, nextNodeData);
    }
    
    [Test]
    public void UsingIndexerMinus1_PreviousNodeReturned()
    {
        OwnList<int> list = new OwnList<int> { 5, 8 };
        OwnList<int>.Node last = list._tail;

        int prevNodeData = last[-1].Data;
        
        Assert.AreEqual(5, prevNodeData);
    }
    
    [Test]
    public void UsingIndexer0_CurrentNodeReturned()
    {
        OwnList<int> list = new OwnList<int> { 5, 15, 8 };
        OwnList<int>.Node current = list._head.Next;

        int currNodeData = current[0].Data;
        
        Assert.AreEqual(15, currNodeData);
    }
    
    [Test]
    public void UsingIndexerBiggerThanPossible_IndexOutOfRangeExceptionThrowed()
    {
        OwnList<int> list = new OwnList<int> { 5, 15, 8 };
        OwnList<int>.Node current = list._head;

        Assert.Catch(typeof(IndexOutOfRangeException), () => { var x = current[3];});
    }

    [Test]
    public void UsingIndexerSmallerThanPossible_IndexOutOfRangeExceptionThrowed()
    {
        OwnList<int> list = new OwnList<int> { 5, 15, 8 };
        OwnList<int>.Node current = list._head;

        Assert.Catch(typeof(IndexOutOfRangeException), () => { var x = current[-1];});
    }
}