using WebApplication2.Dtos;

namespace WebApplication2.Interface
{
    public interface IStudentRepo
    {
        void deletedtudent(int id);
        void putstudent(int id,updateStudent studentPost);
        void postdtudent(StudentPostss studentPost);
        List<StudentPostss> StudentGetAll();
        StudentPostsss StudentGetById(int id);
    }
}
