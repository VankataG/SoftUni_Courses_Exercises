namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
                return true;
            return false;
        }

        public void AddRange(IEnumerable<string> elements)
        {
            foreach (var element in elements)
            {
                this.Push(element);
            }
        }
    }
}
