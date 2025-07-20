using System.Collections;
public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;
    public Node? Insert(int value) => _root is null ? _root = new(value) : _root.Insert(value); //{ if (_root is null) _root = new(value); else _root.Insert(value); }
    public bool Contains(int value) => _root != null && _root.Contains(value);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers) yield return number;
    }
    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is null) return;
        TraverseForward(node.Left, values);
        values.Add(node.Data);
        TraverseForward(node.Right, values);
    }
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers) yield return number;
    }
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is null) return;
        TraverseBackward(node.Right, values);
        values.Add(node.Data);
        TraverseBackward(node.Left, values);
    }
    public int GetHeight() => _root?.GetHeight() ?? 0;
    public override string ToString() => "<Bst>{" + string.Join(", ", this) + "}";
}
public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array) => "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
}