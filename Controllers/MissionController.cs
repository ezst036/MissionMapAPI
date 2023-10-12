using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using missionmap.Data;

namespace missionmap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly DataContext _context;

        public MissionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> Get(int id)
        {
            var mssn = await _context.missionmap_mission.FindAsync(id);
            if (mssn == null)
            {
                return BadRequest("No mission ");
            }

            return Ok(mssn);
        }

        [HttpGet]
        public async Task<ActionResult<List<Mission>>> GetAll()
        {
            return Ok(await _context.missionmap_mission.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Mission>>> Add(Mission newMission)
        {
            _context.missionmap_mission.Add(newMission);
            await _context.SaveChangesAsync();
            return Ok(await _context.missionmap_mission.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Mission>>> Update(Mission updMission)
        {
            _context.missionmap_mission.Update(updMission);
            await _context.SaveChangesAsync();
            return Ok(await _context.missionmap_mission.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Mission>>> Delete(Mission delMission)
        {
            _context.missionmap_mission.Remove(delMission);
            await _context.SaveChangesAsync();
            return Ok(await _context.missionmap_mission.ToListAsync());
        }
    }
}