using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThirdTryOfASPNETCOREWEBAPI.Models;

namespace ThirdTryOfASPNETCOREWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MydbContext context;

        public StudentAPIController(MydbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {

            var data = await context.Students.ToListAsync();
            return Ok(data);
        }


        [HttpGet]

        [Route("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {

                return NotFound();

            }
            return Ok(student);

        }

        [HttpPost]
        [Route ("InsertStudent")]

        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }


        //[HttpPut]
        //[Route("UpdateStudentById/{id}")]
        //public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        //{
        //    context.Entry(std).State = EntityState.Modified;
        //    await context.SaveChangesAsync();
        //    return Ok(std);

        //}

        //public async Task<ActionResult<Student>> UpdateStudent(int id)
        //{
        //    var std = await context.Students.FindAsync(id);
        //    if (std == null)
        //    {
        //        return NotFound();
        //    }
        //    context.Students.Add(std);
        //    await context.SaveChangesAsync();
        //    return Ok(std);

        //}
        [HttpPut]
        [Route("UpdateStudentById/{id}")]
        public async Task<ActionResult<Student>> UpdateStudentById(int id, [FromBody] Student updatedStudent)
        {
            // Find the student by ID
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            // Update the student's properties
            student.StudentName = updatedStudent.StudentName;
            student.Age = updatedStudent.Age;
            student.StudentGender = updatedStudent.StudentGender;
            student.Standerd = updatedStudent.Standerd;
            student.FatherName = updatedStudent.FatherName;
            //Add other properties as needed

            // Mark the student entity as modified
            context.Entry(student).State = EntityState.Modified;

            // Save changes to the database
            await context.SaveChangesAsync();

            return Ok(student);
        }







        [HttpDelete]
        [Route("DeleteStudentById/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}

                        ////  Changing the EndPoints names Here 

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ThirdTryOfASPNETCOREWEBAPI.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace ThirdTryOfASPNETCOREWEBAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentAPIController : ControllerBase
//    {
//        private readonly MydbContext context;

//        public StudentAPIController(MydbContext context)
//        {
//            this.context = context;
//        }

//        /// <summary>
//        /// Retrieves all students.
//        /// </summary>
//        [HttpGet]
//        [Route("GetAllStudents")]
//        public async Task<ActionResult<List<Student>>> GetAllStudents()
//        {
//            var data = await context.Students.ToListAsync();
//            return Ok(data);
//        }

//        /// <summary>
//        /// Retrieves a student by ID.
//        /// </summary>
//        [HttpGet("{id}")]
//        [Route("GetStudentById/{id}")]
//        public async Task<ActionResult<Student>> GetStudentById(int id)
//        {
//            var student = await context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return Ok(student);
//        }

//        /// <summary>
//        /// Inserts a new student.
//        /// </summary>
//        [HttpPost]
//        [Route("InsertStudent")]
//        public async Task<ActionResult<Student>> InsertStudent(Student std)
//        {
//            await context.Students.AddAsync(std);
//            await context.SaveChangesAsync();
//            return Ok(std);
//        }

//        /// <summary>
//        /// Updates a student by ID.
//        /// </summary>
//        [HttpPut("{id}")]
//        [Route("UpdateStudentById/{id}")]
//        public async Task<ActionResult<Student>> UpdateStudentById(int id, Student std)
//        {
//            context.Entry(std).State = EntityState.Modified;
//            await context.SaveChangesAsync();
//            return Ok(std);
//        }

//        /// <summary>
//        /// Deletes a student by ID.
//        /// </summary>
//        [HttpDelete("{id}")]
//        [Route("DeleteStudentById/{id}")]
//        public async Task<ActionResult<Student>> DeleteStudentById(int id)
//        {
//            var std = await context.Students.FindAsync(id);
//            if (std == null)
//            {
//                return NotFound();
//            }
//            context.Students.Remove(std);
//            await context.SaveChangesAsync();
//            return Ok();
//        }
//    }









