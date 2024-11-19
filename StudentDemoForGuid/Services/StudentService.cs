using Microsoft.EntityFrameworkCore;
using StudentDemoForGuid.Exceptions;
using StudentDemoForGuid.Models;
using StudentDemoForGuid.Repositories;

namespace StudentDemoForGuid.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public Guid Add(Student student)
        {
            _repository.Add(student);
            return student.Id;
        }

        public Student Get(Guid id)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                throw new StudentNotFoundException("Student Not Found");
            }
            return student;
        }

        public List<Student> GetAll()
        {
            var students = _repository.GetAll().ToList();
            return students;
        }
    }
}
