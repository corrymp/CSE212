public class Node(int data)
{
    public int Data { get; set; } = data;
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }
    public Node? Insert(int value) => value != Data ? value < Data ? Left is null ? Left = new Node(value) : Left.Insert(value) : Right is null ? Right = new Node(value) : Right.Insert(value) : null; // the "correct" way: { if (value == Data) return; if (value < Data) { if (Left is null) Left = new Node(value); else Left.Insert(value); } else if (Right is null) Right = new Node(value); else Right.Insert(value); }
    public bool Contains(int value) => value == Data || (Left is not null && value < Data ? Left.Contains(value) : Right is not null && Right.Contains(value));
    public int GetHeight() => Math.Max((Left is not null ? Left.GetHeight() : 0) + 1, (Right is not null ? Right.GetHeight() : 0) + 1);
}