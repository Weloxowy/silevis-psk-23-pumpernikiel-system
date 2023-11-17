using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;

namespace SystemZarzadzaniaPraktykami.Controllers.Student
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

            [HttpGet]
            public ActionResult<IEnumerable<Models.Student.Student>> GetAll()
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var klientEntities = session.Query<Models.Student.Student>().ToList();
                    return Ok(klientEntities);
                }
            }
            [HttpGet("{id}")]
            public ActionResult<Models.Student.Student> GetById(Guid id)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var studentEntity = session.Get<Models.Student.Student>(id);

                    if (studentEntity == null)
                    {
                        return NotFound();
                    }

                    return Ok(studentEntity);
                }

            }
            [HttpPost]
            public ActionResult<Models.Student.Student> CreateKlientEntity([FromBody] Models.Student.Student student)
            {
                if (student == null)
                {
                    return BadRequest("Invalid data");
                }
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            session.Save(student);
                            transaction.Commit();
                            return CreatedAtAction(nameof(GetById), new { id = student.id }, student);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                        }
                    }
                }

            }
            [HttpDelete("{id}")]
            public ActionResult DeletePolisy(Guid id)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var student = session.Get<Models.Student.Student>(id);

                            if (student == null)
                            {
                                return NotFound();
                            }


                            session.Delete(student);


                            transaction.Commit();

                            return NoContent();
                        }
                        catch (Exception ex)
                        {

                            transaction.Rollback();
                            return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                        }
                    }
                }
            }
        }
    }

