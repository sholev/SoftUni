namespace EducationSystem.Messages
{
    public static class Errors
    {
        public static string UserNotLoggedIn
            => "There is no currently logged in user.";

        public static string UserAlreadyLoggedIn
            => "There is already a logged in user.";

        public static string UserNotAuthorized 
            => "The current user is not authorized to perform this operation.";

        public static string AlreadyEnrolled 
            => "You are already enrolled in this course.";

        public static string UserNotEnrolled 
            => "You are not enrolled in this course.";

        public static string UserPasswordsNotMatching 
            => "The provided passwords do not match.";

        public static string UserPasswordIsWrong
            => "The provided password is wrong.";

        public static string RouteInvalid
            => "The provided route is invalid.";

        public static string UserDoesNotExist(string username) 
            => $"A user with username {username} does not exist.";
        
        public static string UserNameTaken(string username) 
            => $"A user with username {username} already exists.";

        public static string StringLength(string parameter, int length)
            => $"The {parameter} must be at least {length} symbols long.";

        public static string NoCourseWithId(int id)
            => $"There is no course with ID {id}.";
    }
}
