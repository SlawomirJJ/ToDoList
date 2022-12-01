using TODOList.services;

namespace TODOList.Models
{
    public class DayModel
    {
        public System.DayOfWeek Name { get; set; }
        public DateOnly Date { get; set; }
        public List<TaskModel>? Tasks { get; set; }


        public DayModel(DateOnly day)
        {
            Date = new DateOnly(day.Year, day.Month, day.Day);
            Name = Date.DayOfWeek;

            TasksDAO taskDAO = new();
            Tasks = (taskDAO.GetAllTasksForDay(Date));
            
        }
    }
}
