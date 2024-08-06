using WebApplication1.models;

namespace WebApplication1.interfaces
{
    public interface IStrudentService
    {
        IEnumerable<Students> GetAllStudents();
        Students GetStudentById(int id);
        void AddStudent(Students students);
        void UpdateStudent(Students students);
        void DeleteStudent(int id);
  
    }
}
