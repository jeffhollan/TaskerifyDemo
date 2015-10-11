using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taskerify.Models;
using System.Threading.Tasks;

namespace Taskerify.Controllers
{
    public class UserController : ApiController
    {
        private DataModel db = new DataModel();

        [HttpPost, Route("api/User")]
        public async Task<HttpResponseMessage> AddUser(NewUserModel user)
        {
            User newUser = new User { id = Guid.NewGuid(), name = user.name, email = user.email, phone = user.phone, twitter = user.twitter, processed = 0 };
            db.Users.Add(newUser);
            await db.SaveChangesAsync();
            return Request.CreateResponse("User Added");
        }

        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, "Array of users", typeof(IList<User>))]
        [HttpGet, Route("api/User")]
        public async Task<HttpResponseMessage> GetUsers()
        {
            return Request.CreateResponse<IList<User>>(db.Users.ToList());
        }

        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, "Requested User", typeof(User))]
        [HttpGet, Route("api/User/{id}")]
        public async Task<HttpResponseMessage> GetUser(Guid id)
        {
            return Request.CreateResponse<User>(db.Users.Where(u => u.id == id).FirstOrDefault());
        }

        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK, "Requested User", typeof(User))]
        [HttpGet, Route("api/User/twitter/{handle}")]
        public async Task<HttpResponseMessage> GetUserByTwitter(string handle)
        {
            return Request.CreateResponse<User>(db.Users.Where(u => u.twitter == handle).FirstOrDefault());
        }
    }
}
