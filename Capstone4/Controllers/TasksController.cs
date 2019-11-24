using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Capstone4.Data;
using Capstone4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone4.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskListDbContext _taskContext;
        List<Tasks> userTasks = new List<Tasks>();

        public TasksController(TaskListDbContext context)
        {
            _taskContext = context;
        }

        // GET: /<controller>/
        public IActionResult ListTasks()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            PopulateUserTasks(id);
            return View(userTasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Tasks userTask)
        {
            userTask.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _taskContext.Tasks.Add(userTask);
            _taskContext.SaveChanges();
            return RedirectToAction("ListTasks");
        }

        public IActionResult UpdateTask(int TaskId)
        {
            Tasks findTask = _taskContext.Tasks.Find(TaskId);
            if (findTask.Complete)
            {
                findTask.Complete = false;
            }
            else
            {
                findTask.Complete = true;
            }
            _taskContext.Entry(findTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _taskContext.Update(findTask);
            _taskContext.SaveChanges();
            return RedirectToAction("ListTasks");
        }

        public IActionResult DeleteTask(int TaskId)
        {
            Tasks findTask = _taskContext.Tasks.Find(TaskId);
            findTask.Complete = false;
            _taskContext.Tasks.Remove(findTask);
            _taskContext.SaveChanges();
            return RedirectToAction("ListTasks");
        }

        public void PopulateUserTasks(string id)
        {
            var allTasks = _taskContext.Tasks.ToList();

            foreach (var task in allTasks)
            {
                if (task.UserId == id)
                {
                    userTasks.Add(task);
                }
            }
        }
    }
}