using System.Collections.Generic;

namespace HomeXTest.Domain.Models
{
    public class ActivityNode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentActivityId { get; set; }

        public List<Person> People { get; set; }

        public List<ActivityNode> Children { get; set; }
    }
}