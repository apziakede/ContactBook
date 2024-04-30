using ContactBook.Models;
using ContactBook.Repository;
using Microsoft.AspNetCore.Mvc;
using static ContactBook.DTOs.ContactDTO;

namespace ContactBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly ContactRepository _contactRepo;

        public ContactsController( )
        {
            _contactRepo = new();
        }
      
        [HttpPost]
        public string Post([FromBody] ContactCreateDTO contact)
        {
            if (ModelState.IsValid)
            {
                var result = _contactRepo.Create(contact);
                if (result == "success")
                    return "success";
                else
                    return result;
            }
            else
            {
                return "Kindly provide valid values for all the required fields to continue.";
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public string Put([FromBody] ContactUpdateDTO contact)
        {
            if (ModelState.IsValid)
            {
                var result = _contactRepo.Update(contact);
                if (result == "success")
                    return "success";
                else
                    return result;
            }
            else
            {
                return "Kindly provide valid values for all the required fields to continue.";
            }
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<ContactsDTO> Get()
        {
            return _contactRepo.GetAll();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ContactsDTO Get(int id)
        {
            return _contactRepo.Get(id);
        }
    }
}
