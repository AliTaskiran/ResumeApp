using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ResumeApp.Controllers
{
    public class JobPostingController : Controller
    {
        private readonly IJobPostingService _jobPostingService;

        public JobPostingController(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }

        public IActionResult Index()
        {
            var jobs = _jobPostingService.TGetList()
                .Where(j => j.IsActive && !j.IsFilled)
                .OrderByDescending(j => j.CreatedDate)
                .ToList();

            return View(jobs);
        }

        public IActionResult Details(int id)
        {
            var job = _jobPostingService.TGetById(id);
            if (job == null || !job.IsActive || job.IsFilled)
            {
                return NotFound();
            }

            return View(job);
        }
    }
} 