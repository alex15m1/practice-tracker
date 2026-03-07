using Microsoft.AspNetCore.Mvc;
using PracticeTracker.Data;
using PracticeTracker.Models;

namespace PracticeTracker.Controllers
{
    public class PracticeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PracticeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Calendar(int? year, int? month)
        {
            DateTime today = DateTime.Today;

            int selectedYear;
            if (year != null) selectedYear = year.Value;
            else selectedYear = today.Year;

            int selectedMonth;
            if (month != null) selectedMonth = month.Value;
            else selectedMonth = today.Month;

            DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

            List<PracticeEntry> entriesForMonth = new List<PracticeEntry>();
            foreach (PracticeEntry entry in _context.PracticeEntries)
            {
                if (entry.Date.Year == selectedYear && entry.Date.Month == selectedMonth)
                {
                    entriesForMonth.Add(entry);
                }
            }

            // index = day number (1..daysInMonth)
            string[] dayStatuses = new string[daysInMonth + 1];

            for (int day = 1; day <= daysInMonth; day++)
            {
                List<PracticeEntry> entriesForDay = new List<PracticeEntry>();

                foreach (PracticeEntry entry in entriesForMonth)
                {
                    if (entry.Date.Day == day)
                    {
                        entriesForDay.Add(entry);
                    }
                }

                if (entriesForDay.Count > 0)
                {
                    dayStatuses[day] = GetDayStatus(entriesForDay);
                }
                else
                {
                    dayStatuses[day] = "";
                }
            }

            ViewBag.Year = selectedYear;
            ViewBag.Month = selectedMonth;
            ViewBag.FirstDayOfMonth = firstDayOfMonth;
            ViewBag.DaysInMonth = daysInMonth;
            ViewBag.DayStatuses = dayStatuses;

            return View();
        }

        private static string GetDayStatus(List<PracticeEntry> entriesForDay)
        {
            int minutes = 0;
            bool warmUp = false;
            bool scales = false;
            bool intonation = false;
            bool technical = false;

            foreach (PracticeEntry entry in entriesForDay)
            {
                minutes += entry.MinutesPracticed;

                if (entry.WarmUp) warmUp = true;
                if (entry.Scales) scales = true;
                if (entry.Intonation) intonation = true;
                if (entry.TechnicalExercises) technical = true;
            }

            int score = 0;
            if (warmUp) score++;
            if (scales) score++;
            if (intonation) score++;
            if (technical) score++;

            if (minutes >= 60) score += 2;
            else if (minutes >= 30) score += 1;

            if (score >= 5) return "good";
            if (score >= 3) return "okay";
            return "bad";
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PracticeEntry entry)
        {
            if (ModelState.IsValid)
            {
                _context.PracticeEntries.Add(entry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        public IActionResult Index()
        {
            List<PracticeEntry> entries = new List<PracticeEntry>();
            foreach (PracticeEntry entry in _context.PracticeEntries)
            {
                entries.Add(entry);
            }

            for (int i = 0; i < entries.Count - 1; i++)
            {
                for (int j = i + 1; j < entries.Count; j++)
                {
                    if (entries[j].Date > entries[i].Date)
                    {
                        PracticeEntry temp = entries[i];
                        entries[i] = entries[j];
                        entries[j] = temp;
                    }
                }
            }

            return View(entries);
        }
    }
}
