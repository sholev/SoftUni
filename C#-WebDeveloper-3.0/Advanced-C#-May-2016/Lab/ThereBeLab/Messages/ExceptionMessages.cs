namespace ThereBeLab.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidDepthNumber = 
            "Invalid depth parameter.";

        public const string DataAlreadyInitialized = 
            "Data is already initialized.";

        public const string DataNotInitialized =
            "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingCourseInDatabase =
            "The course you are trying to get does not exist in the data base.";

        public const string InexistingStudentInDatabase =
            "The user name for the student you are trying to get does not exist.";

        public const string InvalidPath =
            "The path you've entered does not exist.";

        public const string UnauthorizedAccessExceptionMessage =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = 
            "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";
        
        public const string UnableToGoHigherInPartitionHierarchy = 
            "I'm sorry Mario! The princess is in another castle.";

        public const string InvalidParameters = 
            "The number of parameters was invalid";
    }
}
