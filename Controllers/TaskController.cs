using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfficientTaskManager.Models;
using EfficientTaskManager.Services;

namespace EfficientTaskManager.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: /Task
        public IActionResult Index()
        {
            var tasks = _taskService.GetAllTasks(User.Identity.Name);
            return View(tasks);
        }

        // GET: /Task/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task model)
        {
            if (ModelState.IsValid)
            {
                _taskService.CreateTask(model, User.Identity.Name);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Task/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _taskService.GetTaskById(id, User.Identity.Name);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: /Task/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Task model)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(model, User.Identity.Name);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: /Task/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _taskService.DeleteTask(id, User.Identity.Name);
            return RedirectToAction("Index");
        }

        // GET: /Task/Details/{id}
        [HttpGet]
        public IActionResult Details(int id)
        {
            var task = _taskService.GetTaskById(id, User.Identity.Name);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }
    }
}
