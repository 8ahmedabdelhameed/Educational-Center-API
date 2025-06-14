using WebApplication2.Dtos;

namespace WebApplication2.Interface
{
    public interface ISubjectRepo
    {
        void postSub (SubjectPost subjectPost);
        List<SubjectPost> getAllSub();
        SubjectGetById getSubbyid(int subjectid);
    }
}
