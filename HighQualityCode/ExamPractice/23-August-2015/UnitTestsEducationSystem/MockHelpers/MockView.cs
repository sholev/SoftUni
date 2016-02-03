namespace UnitTestsEducationSystem.MockHelpers
{
    using System.Text;
    
    using EducationSystem.Views;

    public class MockView : View
    {
        public MockView(string mockedMessage)
            : base(null)
        {
            this.Message = mockedMessage;
        }
        
        public MockView(object model)
            : base(model)
        {
        }

        private string Message { get; set; }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(this.Message);
        }
    }
}
