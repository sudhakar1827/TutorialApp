namespace asp.netCoreIntro.Models
{
    public class Child
    {
        public int ChildId { get; set; }
        public string? ChildName { get; set; }

        public int ParentId { get; set; }
        public Parent? Parent { get; set; }
    }
}
