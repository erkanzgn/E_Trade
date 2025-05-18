using ETrade.DtoLayer.CatalogDtos.ContactDtos;
using ETrade.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;

namespace ETrade.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "Trendshop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Mesaj Gönder";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        { 
            createContactDto.IsRead = false;
            createContactDto.SenDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index","Default");

          
        
        }

    }
}
