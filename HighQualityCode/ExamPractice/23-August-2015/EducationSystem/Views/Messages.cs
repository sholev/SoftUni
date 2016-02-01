namespace EducationSystem.Views
{
    public static class Messages
    {
        public static string GetLengthMessage(string parameter, int length)
            => $"The {parameter} must be at least {length} symbols long.";
    }
}
