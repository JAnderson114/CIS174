using Microsoft.AspNetCore.Mvc;
using CIS174_M06RazorTemplates.Models;

namespace CIS174_M06RazorTemplates.Controllers
{
    public class Assignment7_1Controller : Controller
    {
        private List<OlympicCountry> GetCountries()
        {
            return new List<OlympicCountry>
            {
                new OlympicCountry { Country = "Austria", Game = "Paralympic Games", Sport = "Canoe Sprint", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/at.png" },
                new OlympicCountry { Country = "Brazil", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/br.png" },
                new OlympicCountry { Country = "Canada", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/ca.png" },
                new OlympicCountry { Country = "China", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/cn.png" },
                new OlympicCountry { Country = "Cyprus", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/cy.png" },
                new OlympicCountry { Country = "Finland", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/fi.png" },
                new OlympicCountry { Country = "France", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/fr.png" },
                new OlympicCountry { Country = "Germany", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/de.png" },
                new OlympicCountry { Country = "Great Britain", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/gb.png" },
                new OlympicCountry { Country = "Italy", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/it.png" },
                new OlympicCountry { Country = "Jamaica", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/jm.png" },
                new OlympicCountry { Country = "Japan", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/jp.png" },
                new OlympicCountry { Country = "Mexico", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/mx.png" },
                new OlympicCountry { Country = "Netherlands", Game = "Summer Olympics", Sport = "Cycling", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/nl.png" },
                new OlympicCountry { Country = "Pakistan", Game = "Paralympic Games", Sport = "Canoe Sprint", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/pk.png" },
                new OlympicCountry { Country = "Portugal", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/pt.png" },
                new OlympicCountry { Country = "Russia", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/ru.png" },
                new OlympicCountry { Country = "Slovakia", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/sk.png" },
                new OlympicCountry { Country = "Sweden", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/se.png" },
                new OlympicCountry { Country = "Thailand", Game = "Paralympic Games", Sport = "Archery", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/th.png" },
                new OlympicCountry { Country = "Ukraine", Game = "Paralympic Games", Sport = "Archery", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/ua.png" },
                new OlympicCountry { Country = "USA", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/us.png" },
                new OlympicCountry { Country = "Uruguay", Game = "Paralympic Games", Sport = "Archery", Category = "Indoor", FlagImage = "https://flagcdn.com/w80/uy.png" },
                new OlympicCountry { Country = "Zimbabwe", Game = "Paralympic Games", Sport = "Canoe Sprint", Category = "Outdoor", FlagImage = "https://flagcdn.com/w80/zw.png" }
            };
        }

        public IActionResult Index(OlympicFilter filter)
        {
            var countries = GetCountries();

            ViewBag.ActiveGame = filter.ActiveGame;
            ViewBag.ActiveCategory = filter.ActiveCategory;

            ViewBag.Games = new List<string>
            {
                "Summer Olympics",
                "Winter Olympics",
                "Paralympic Games",
                "Youth Olympic Games"
            };

            ViewBag.Categories = new List<string>
            {
                "Indoor",
                "Outdoor"
            };

            IEnumerable<OlympicCountry> query = countries.OrderBy(c => c.Country);

            if (filter.ActiveGame != "all")
            {
                query = query.Where(c => c.Game == filter.ActiveGame);
            }

            if (filter.ActiveCategory != "all")
            {
                query = query.Where(c => c.Category == filter.ActiveCategory);
            }

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult Details(
            string id,
            string activeGame = "all",
            string activeCategory = "all")
        {
            var country = GetCountries().FirstOrDefault(c => c.Country == id);

            if (country == null)
            {
                return NotFound();
            }

            ViewBag.ActiveGame = activeGame;
            ViewBag.ActiveCategory = activeCategory;

            var session = new OlympicSession(HttpContext.Session);

            ViewBag.IsFavorite = session.IsFavorite(country.Country);

            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(
            string country,
            string activeGame = "all",
            string activeCategory = "all")
        {
            var selectedCountry = GetCountries()
                                  .FirstOrDefault(c => c.Country == country);

            if (selectedCountry == null)
            {
                return NotFound();
            }

            var session = new OlympicSession(HttpContext.Session);
            var favorites = session.GetFavorites();

            if (!favorites.Any(c => c.Country == selectedCountry.Country))
            {
                favorites.Add(selectedCountry);
                session.SetFavorites(favorites);

                TempData["message"] = $"{selectedCountry.Country} added to your favorites.";
            }
            else
            {
                TempData["message"] = $"{selectedCountry.Country} is already in your favorites.";
            }

            return RedirectToAction(
                nameof(Details),
                new
                {
                    id = selectedCountry.Country,
                    activeGame,
                    activeCategory
                });
        }
    }
}