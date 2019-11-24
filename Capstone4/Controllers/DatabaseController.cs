using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone4.Data;
using Capstone4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone4.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly TaskListDbContext _dbContext;
        private readonly ApplicationDbContext _identityContext;
        public DatabaseController(TaskListDbContext dbContext, ApplicationDbContext identityContext)
        {
            _dbContext = dbContext;
            _identityContext = identityContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}