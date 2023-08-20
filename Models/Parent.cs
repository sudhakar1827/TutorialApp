namespace asp.netCoreIntro.Models
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
