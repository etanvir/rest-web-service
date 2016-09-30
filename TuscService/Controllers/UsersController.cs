using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

using TuscData;
namespace TuscService.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<User>
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Get()
        {
            return DataManager.GetUsers();
        }

        // GET api/<User>/5
        [HttpGet]
        [Route("users/{id}")]
        public User Get(int id)
        {
            return DataManager.GetUsers().Where(u=> u.Id == id).FirstOrDefault();    
        }

        //Get /users?sortBalance={ASC|DESC}
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> Getorderedusers(string ASC)
        { 
            List<User> users;
            List<User> sortedlist;

            users = DataManager.GetUsers();
            if(ASC =="ASC")
                sortedlist = users.OrderBy(u => u.Balance).ToList();
            else
                sortedlist = users.OrderByDescending(u => u.Balance).ToList();
                 return null;
        }

        // POST api/<User>
        [HttpPost]
        [Route("users")]
        public int? Post([FromBody]User user)
        {
            return DataManager.CreateUser(user);
        }

        // PUT api/<User>/5
        [HttpPut]
        [Route("users/{id}")]
        public void Put(int id, [FromBody]User user)
        {
            user.Id = id;
            DataManager.UpdateUser(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("users/{id}")]
        public void Delete(int id)
        {
            DataManager.DeleteUser(id);
        }
    }
}