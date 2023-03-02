using Persistence;
using Microsoft.AspNetCore.Mvc;  // to powinno sie dodac przez BaseApiController!! czemu musze to tutaj dodawac
using Domain; // to powinno sie dodac przez BaseApiController!! czemu musze to tutaj dodawac (inaczej nie dziala [HttpGet])
using Microsoft.EntityFrameworkCore; //tego tez nie powinnam dodawac ale nie ma ToListAsynch()


namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
   
        public ActivitiesController(DataContext context)
         {
            _context = context;
          }
        [HttpGet] //api/acitivities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

       [HttpGet("{id}")] //api/activities/dfdfef

       public async Task<ActionResult<Activity>> GetActivity(Guid id)
       {
        return await _context.Activities.FindAsync(id);
       }
 
    }
    
    
}