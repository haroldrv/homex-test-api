using System.ComponentModel.DataAnnotations.Schema;

namespace HomeXTest.Domain.Models
{
    [Table("activities_people")]
    public class ActivitiesPeople
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? activity_id { get; set; }

        public int? person_id { get; set; }

        public virtual Activity activity { get; set; }
    }
}