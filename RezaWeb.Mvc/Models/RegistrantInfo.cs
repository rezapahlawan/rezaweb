using System.ComponentModel.DataAnnotations;

namespace RezaWeb.Mvc.Models
{
    public class RegistrantInfo
    {
        public virtual int RegistrantInfoId { get; set; }

        [Required(ErrorMessage="Nama Lengkap harus diisi")]
        [Display(Name="Nama Lengkap")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Jenis Kelamin harus diisi")]
        [Display(Name="Jenis Kelamin")]
        public virtual string Sex { get; set; }

        [Required(ErrorMessage = "Tempat Lahir harus diisi")]
        [Display(Name="Tempat Lahir")]
        public virtual string BirthPlace { get; set; }

        [Required(ErrorMessage = "Tanggal Lahir harus diisi")]
        [Display(Name="Tanggal Lahir")]
        public virtual string BirthDate { get; set; }

        [Required(ErrorMessage = "Alamat Lengkap harus diisi")]
        [DataType(DataType.MultilineText)]
        public virtual string Address { get; set; }

        [Display(Name="Nomor Ujian")]
        public virtual string ExamNumber { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public void Update(RegistrantInfo newValue)
        {
            Name = newValue.Name;
            Sex = newValue.Sex;
            BirthPlace = newValue.BirthPlace;
            BirthDate = newValue.BirthDate;
            Address = newValue.Address;
            ExamNumber = newValue.ExamNumber;
        }
    }
}