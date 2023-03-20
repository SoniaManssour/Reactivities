using Persistence;
using Microsoft.AspNetCore.Mvc;  // to powinno sie dodac przez BaseApiController!! czemu musze to tutaj dodawac
using Domain; // to powinno sie dodac przez BaseApiController!! czemu musze to tutaj dodawac (inaczej nie dziala [HttpGet])
using Microsoft.EntityFrameworkCore; //tego tez nie powinnam dodawac ale nie ma ToListAsynch()
using MediatR;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet] //api/acitivities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

       [HttpGet("{id}")] //api/activities/dfdfef

       public async Task<ActionResult<Activity>> GetActivity(Guid id)
       {
        return await Mediator.Send(new Details.Query{Id = id});
       }

       [HttpPost] // add new endpoint
       public async Task<IActionResult> CreateActivity(Activity activity) // from body
       {
        return Ok(await Mediator.Send(new Create.Command {Activity = activity} ));
       }

       [HttpPut("{id}")] 

       public async Task <IActionResult> EditActivity(Guid id, Activity activity)
       {
        activity.Id = id;
        return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
       }

       [HttpDelete("{id}")]

       public async Task<IActionResult> DeleteActivity(Guid id)
       {
        return Ok(await Mediator.Send(new Delete.Command{Id = id})); 
       }

    
    }
    
}