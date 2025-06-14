using WebApplication2.Dtos;

namespace WebApplication2.Interface
{
    public interface ITeacherRepo
    {
  TeacherGetById TeacherGetById(int id);
        List<TeacherGetAll> TeacherGetAll();
        void postteacher(Teacherpost teacherpost);
    }
}
