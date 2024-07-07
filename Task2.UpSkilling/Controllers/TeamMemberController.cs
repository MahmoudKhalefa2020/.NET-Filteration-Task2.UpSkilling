using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.UpSkilling.Data;
using Task2.UpSkilling.Dtos;
using Task2.UpSkilling.Models;

namespace Task2.UpSkilling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TeamMemberController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMemberDto>>> GetAll()
        {
            var teamMembers = await _context.TeamMembers.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TeamMemberDto>>(teamMembers));


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMemberDto>> GetById(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            return Ok(_mapper.Map<TeamMemberDto>(teamMember));
        }
        [HttpPost]
        public async Task<ActionResult<TeamMemberDto>> Add(TeamMemberDto teamMemberDto)
        {
            var teamMember = _mapper.Map<TeamMember>(teamMemberDto);
            var result = await _context.AddAsync(teamMember);
            await _context.SaveChangesAsync();
            return Ok(new StatusCodeResult(StatusCodes.Status201Created));
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<TeamMemberDto>> Edit(int id, TeamMemberDto teamMemberDto)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            //teamMember.Name = teamMemberDto.Name;
            //teamMember.Email = teamMemberDto.Email;
            _mapper.Map(teamMemberDto, teamMember);
            _mapper.Map<TeamMemberDto>(teamMember);
            await _context.SaveChangesAsync();
            return Ok("Edited");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember is null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
            return Ok(teamMember);
        }


































    }
}
