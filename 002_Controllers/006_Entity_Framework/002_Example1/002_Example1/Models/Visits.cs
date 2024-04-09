using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _002_Example1.Models
{
    public class Visits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctors Doctors { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patients Patients { get; set; }

    }
}
