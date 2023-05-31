namespace Tree.Models
{
    public class Node // element in the tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Node> Children { get; set; } = new List<Node>();
    }
}
