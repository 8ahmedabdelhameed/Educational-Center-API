using WebApplication2.Dtos;

namespace WebApplication2.Interface
{
    public interface IGradRepo
    {
        void postgrad (GradDtos grad, int id);
    }
}
