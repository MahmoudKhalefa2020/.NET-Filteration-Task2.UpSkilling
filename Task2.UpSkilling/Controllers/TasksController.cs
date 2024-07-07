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
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TasksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksDto>>> GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TasksDto>>(tasks));

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TasksDto>> GetById(int id)
        {

            var task = await _context.Tasks.FindAsync(id);
            if (task is null)

                return new StatusCodeResult(StatusCodes.Status404NotFound);

            return Ok(_mapper.Map<TasksDto>(task));



        }

        [HttpPost]
        public async Task<ActionResult<TasksDto>> Add([FromForm] TasksDto tasksDto)
        {
            var newTask = _mapper.Map<Tasks>(tasksDto);
            var result = await _context.Tasks.AddAsync(newTask);
            _context.SaveChanges();
            return new StatusCodeResult(StatusCodes.Status201Created);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TasksDto>> Edit(int id, TasksDto tasksDto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            _mapper.Map(tasksDto, task);
            _context.SaveChanges();
            return Ok("Updated");

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TasksDto>> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);

            var result = _context.Tasks.Remove(task);
            _context.SaveChanges();
            return Ok(task);
        }
















    }
}
