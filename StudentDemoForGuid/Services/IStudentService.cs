using StudentDemoForGuid.Models;

namespace StudentDemoForGuid.Services
{
    public interface IStudentService
    {
        public List<Student> GetAll();
        public Student Get(Guid id);
        public Guid Add(Student student);
    }
}
