using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Taskerify.Controllers
{
    public class TaskController : ApiController
    {
        private DataModel db = new DataModel();

        [HttpPost, Route("api/Task")]
        public async Task<HttpResponseMessage> AddTask(Models.Task task)
        {
            var owner = db.Users.Where(u => u.id == task.ownerId).FirstOrDefault();
            if (owner == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Owner ID Does not exist. Please check your input and try again");
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return Request.CreateResponse("Task Created");
        }

        [HttpGet, Route("api/Task")]
        public async Task<HttpResponseMessage> GetTasks()
        {
            return Request.CreateResponse<IList<Models.Task>>(db.Tasks.ToList());
        }
    }
}
