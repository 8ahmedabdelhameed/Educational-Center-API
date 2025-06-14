namespace WebApplication2.Dtos
{
    public class SubjectGet
    {
        public int SubjectId { get; set; }
        public string SubjectDuration { get; set; }
          public string SubjectName { get; set; }

    }
    public class SubjectGetAll
    {
        public int SubjectId { get; set; }
        public string SubjectDuration { get; set; }
        public string SubjectName { get; set; }
        public List<StudentPost> studentPosts { get; set; }
    }
    public class SubjectGetById
    {
        public string SubjectDuration { get; set; }
        public string SubjectName { get; set; }
        public List<StudentPostGrads> Students { get; set; }

    }
    public class SubjectPost
    {
        public string SubjectDuration { get; set; }
        public string SubjectName { get; set; }
        public List<StudentPostSub> Students { get; set; }
    }
}
