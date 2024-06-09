

namespace Task1
{
    public class Marriage
    {
        public DateTime? DateOfMarriage { get; set; } = null;
        public DateTime? DateOfDevorce { get; set; } = null;
        public FamalyMember Wife { get; set; } = null;
        public FamalyMember Husband { get; set; } = null;
    }
}
