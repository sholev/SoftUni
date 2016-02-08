namespace EducationSystem.Interfaces
{
    public interface IView
    {
        object Model { get; }

        string Display();
    }
}