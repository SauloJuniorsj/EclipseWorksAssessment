namespace EclipseWorksAssessment.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            
        }
        public UserViewModel(int id, string name, List<ProjectViewModel> projects)
        {
            Id = id;
            Name = name;
            Projects = projects;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
    }
}
