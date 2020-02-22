using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HobbyHub.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HobbyHub.Controllers
{
    public class HomeController : Controller
    {
        private Context context;

        public HomeController(Context dbContext)
        {
            context = dbContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel modelData)
        {
            Login Submit = modelData.LogEm;
            if(ModelState.IsValid)
            {
                User UserInDb = context.Users.FirstOrDefault(u => u.Username == Submit.Username);

                if(UserInDb == null)
                {
                    ModelState.AddModelError("Username", "Username not found");
                    return View("Index");
                }
                PasswordHasher<Login> hasher = new PasswordHasher<Login>();

                PasswordVerificationResult result = hasher.VerifyHashedPassword(Submit, UserInDb.Password, Submit.Password);

                if(result == 0)
                {
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserId", UserInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("register")]
        public IActionResult Register (LoginViewModel modelData)
        {
            User newUser = modelData.NewReg;
            if(ModelState.IsValid)
            {
                User UserInDb = context.Users.FirstOrDefault(u => u.Username == newUser.Username);

                if(UserInDb != null)
                {
                    ModelState.AddModelError("Username", "Username already exists. Please select a new one or login.");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                context.Users.Add(newUser);
                context.SaveChanges();
                
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("hobby")]
        public IActionResult Dashboard ()
        {
            if(HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction ("Index");
            }
            List<Hobby> AllHobbies = context.Hobbies.OrderByDescending(h => h.CreatedAt).Include(h => h.Users).ThenInclude(h => h.User).ToList();
            return View(AllHobbies);
        }

        [HttpGet("hobby/{HobbyId}")]
        public IActionResult HobbyDetail(int HobbyId)
        {
            Hobby Detail = context.Hobbies.Where(h => h.HobbyId == HobbyId).Include(h => h.Users).ThenInclude(h => h.User).FirstOrDefault();

            ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");

            return View(Detail);
        }

        [HttpGet("hobby/new")]
        public IActionResult NewHobby()
        {
            return View();
        }

        [HttpGet("hobby/edit/{HobbyId}")]
        public IActionResult EditHobby(int HobbyId)
        {
            Hobby EditMe = context.Hobbies.FirstOrDefault(h =>h.HobbyId == HobbyId);
            ViewBag.UserId = (int)HttpContext.Session.GetInt32("UserId");
            return View(EditMe);
        }

        [HttpPost("hobby/update")]
        public IActionResult Update(Hobby Updated)
        {
            if (ModelState.IsValid)
            {
                context.Hobbies.Update(Updated);
                context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("EditHobby", Updated.HobbyId);
        }

        [HttpGet("myhobbies/{HobbyId}")]
        public IActionResult AddToMyHobbies (int HobbyId)
        {
            Enthusiast AlreadyAdded = context.Enthusiasts.FirstOrDefault(e => e.HobbyId == HobbyId && e.UserId == (int)HttpContext.Session.GetInt32("UserId"));

            if(AlreadyAdded != null)
            {
                ViewBag.Message = "You Already Added this hobby";

                Hobby hobbyBefore = context.Hobbies.Where(h => h.HobbyId == HobbyId).Include(h => h.Users).ThenInclude(h => h.User).FirstOrDefault();

                return View("HobbyDetail", hobbyBefore);
            }
            context.Enthusiasts.Add(new Enthusiast(){
                UserId = (int) HttpContext.Session.GetInt32("UserId"),
                HobbyId = HobbyId
                });
            context.SaveChanges();
            Hobby hobbyAfter = context.Hobbies.Where(h => h.HobbyId == HobbyId).Include(h => h.Users).ThenInclude(h => h.User).FirstOrDefault();

            return View ("HobbyDetail", hobbyAfter);
        }

        [HttpPost("create")]
        public IActionResult AddHobby(Hobby newHobby)
        {
            if(ModelState.IsValid)
            {
                Hobby Exists = context.Hobbies.FirstOrDefault(h => h.Name == newHobby.Name);

                if(Exists != null)
                {
                    ModelState.AddModelError("Name", "The hobby name needs to be unique.");
                    return View("NewHobby");
                }
                else
                {
                    context.Hobbies.Add(newHobby);
                    context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
            return View("NewHobby");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("seed")]
        public IActionResult Seed()
        {
            context.Hobbies.Add ( new Hobby(){
                Name = "Fishing",
                Description = "Going out for some trout, so kiss my bass!"
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Basketball",
                Description = "If you love to dunk, swoosh, crossover and make it rain, then this is the hobby for you!"
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Knitting",
                Description = "It's not just for Grandma anymore! Take up knitting and learn why Forbes is calling it the next great form of meditation."
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Soccer",
                Description = "Ronaldo bobs and weaves through competitors with ease. The world's favorite sport can be your favorite too. It can also get a little 'Messi' wink, wink!"
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Web Development",
                Description = "If you can dream it you can build it. Pick up programming and learn to build software for you, your freinds and as a career."
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Being a Foodie",
                Description = "This is a newer hobby to our list. Sparked by a millenial craze to continually document their food with pictures, being a foodie can be both yummy and lucrative."
            });

            context.Hobbies.Add ( new Hobby(){
                Name = "Watching Movies",
                Description = "This ain't 'Sleepless in Seattle!' Bouncing off the walls in Boise? Time to head to the movies, get some popcorn and relax. Laugh, cry, and take in the action. You'll be ready to go back to reality in style."
            });

            context.SaveChanges();
            
            return RedirectToAction ("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
