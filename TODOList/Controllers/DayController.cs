using Microsoft.AspNetCore.Mvc;
using TODOList.Models;
using TODOList.services;

namespace TODOList.Controllers
{
    public class DayController : Controller
    {
        public IActionResult Index()
        {
            DateTime today = DateTime.Now;
            DateOnly dateOnlyToday = DateOnly.FromDateTime(today);

            List<DayModel> daysList = new();

            for (int i = 0; i < 7; i++)
            {
                var calcDay = dateOnlyToday.AddDays(i);

                daysList.Add(new DayModel(calcDay));
            }

            return View(daysList);
        }
        
        public IActionResult MarkAsDone(int Id)
        {
            TasksDAO taskDAO = new();
            TaskModel task = taskDAO.GetTask(Id);

            task.IsDone = true;
          
            taskDAO.Update(task);

            return PartialView("DoneTask", task);
        }

        /*
        public IActionResult DetailsTask(int Id)
        {
            TasksDAO taskDAO = new();
            //TaskModel task = new();
            TaskModel task = taskDAO.GetTask(Id);

            string page;
            if (task.IsDone == true)
                page = "DoneTask";
            else
                page = "DetailsTask";

            return PartialView(page, task);
        } */



    }
}
