using Microsoft.AspNetCore.Mvc;
using RestForCD.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestForCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private TeachersRepository _repository;
        public TeachersController(TeachersRepository teachersRepository)
        {
            _repository = teachersRepository;
        }
        // GET: api/<TeachersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            List<Teacher> teachers = _repository.GetAll();
            if (teachers.Count < 1)
            {
                return NoContent();
            }
            return Ok(teachers);
        }

        // GET api/<TeachersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher? foundTeacher = _repository.GetById(id);
            if (foundTeacher == null)
            {
                return NoContent();
            }
            return Ok(foundTeacher);
        }

        // POST api/<TeachersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Teacher> Post([FromBody] Teacher newTeacher)
        {
            try
            {
                Teacher createdTeacher = _repository.Add(newTeacher);
                return Created($"/{createdTeacher.Id}", newTeacher);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TeachersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Teacher> Put(int id, [FromBody] Teacher value)
        {
            try
            {
                Teacher? updatedTeacher = _repository.Update(id, value);
                if (updatedTeacher == null)
                {
                    return NotFound();
                }
                return Ok(updatedTeacher);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<TeacherController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Teacher> Delete(int id)
        {
            Teacher? deletedTeacher = _repository.Delete(id);
            if (deletedTeacher == null)
            {
                return NoContent();
            }
            return Ok(deletedTeacher);
        }
    }
}
