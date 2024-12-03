namespace EclipseWorksAssessment.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }
        public UserViewModel(int id, string name, CollectionProjectViewModel projects)
        {
            Id = id;
            Name = name;
            Projects = projects;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public CollectionProjectViewModel Projects { get; set; }
    }
}
