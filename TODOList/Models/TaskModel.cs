using System.ComponentModel.DataAnnotations;

namespace TODOList.Models
{
    public class TaskModel
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Display(Name = "is done ?")]
        public bool IsDone { set; get; }
        public DateOnly Date { set; get; }
        public string? Priority { set; get; }
        public bool Regularity { set; get; }
        [DataType(DataType.Time)]
        //[DisplayFormat (DataFormatString = "{HH:mm}")]
        public TimeSpan StartTime { set; get; }
        [DataType(DataType.Time)]
        public TimeSpan EndTime { set; get; }
        public string? Description { set; get; }

    }
}
