namespace ThereBeLab.Messages
{
    public class ExceptionMessages
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
            "The path you've entered is invalid.";

        public const string InvalidFile =
            "The file you've entered is invalid.";

        public const string UnauthorizedAccessExceptionMessage =
            "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string ComparisonOfFilesWithDifferentSizes = 
            "Files not of equal size, certain mismatch.";

        public const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public const string UnableToGoHigherInPartitionHierarchy =
            "I'm sorry Mario! This message is in another castle.";

        public const string InvalidParameters =
            "The number of parameters was invalid";

        public const string InvalidEntry =
            "Invalid entry in data: ";

        public const string InvalidStudentsFilter =
            "The given filter should be one of the following: excellent/average/poor";

        public const string InvalidComparisonQuery =
            "Only ascending/descending comparison is supported.";

        public const string InvalidTakeCommand =
            "The take command expected does not match the required format.";

        public const string InvalidTakeQuantityParameter =
            "The take quantity parameter was invalid.";

        public const string InvalidOrderCommand =
            "The order command expected does not match the required format.";

        public const string InvalidOrderQuantityParameter =
            "The order quantity parameter was invalid.";
    }
}