namespace OwnListLib;

public partial class OwnList<T>
{
    public class Node
    {
        public T Data;
        public Node? Next, Previous;

        public Node(T data)
        {
            Data = data;
        }
        
        public Node this[int index]
        {
            get
            {
                if (index == 0) return this;
                if (index > 0)
                {
                    if (Next is not null) return Next[index - 1];
                    throw new IndexOutOfRangeException();
                }
                if (Previous is not null) return Previous[index + 1];
                throw new IndexOutOfRangeException();
            }
        }
    }
}