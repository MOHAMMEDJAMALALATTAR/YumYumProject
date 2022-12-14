namespace Yumyum.Data.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = String.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = String.Empty;
    }
}
