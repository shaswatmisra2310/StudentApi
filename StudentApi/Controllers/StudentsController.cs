using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Context;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        public StudentsController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var student_list = _context.student_table.ToList();
            if (student_list.Count == 0)
                return NotFound();
            return Ok(student_list);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(Guid id)
        {
            var student = _context.student_table.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        
        
        [HttpPut("{id}")]
        public IActionResult PutStudent(Guid id,[FromBody] PutDto putdto)
        {
            Student student = _context.student_table.FirstOrDefault<Student>(s => s.Guid == id);
            if (student==null)
            {
                return BadRequest();
            }
            //student.Name = putdto.Name;
            //student.PasswordHash = putdto.PasswordHash;
            //student.MobileNo = putdto.MobileNo;
            //student.EmailID = putdto.EmailID;
            //student.JoiningDate = putdto.JoiningDate;
            student=_mapper.Map<Student>(putdto);
            try
            {
                _context.student_table.Add(student);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] PostDto request)
        {
            Student student = new Student();
            //student.Name = request.Name;
            //student.LastEditedDate = DateTime.Now;
            ////student.DateofBirth = request.DateofBirth;
            //student.EmailID = request.EmailID;
            //student.MobileNo = request.MobileNo;
            ////student.Subjects = request.Subjects;
            //student.PasswordHash = request.PasswordHash;
            student=_mapper.Map<Student>(request);
            try
            {
                _context.student_table.Add(student);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

          
            return CreatedAtAction("GetStudent", new { id = student.Guid }, student);
        }


       
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var student = _context.student_table.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.student_table.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }

        private bool StudentExists(Guid id)
        {
            return _context.student_table.Any(e => e.Guid == id);
        }
    }
}
