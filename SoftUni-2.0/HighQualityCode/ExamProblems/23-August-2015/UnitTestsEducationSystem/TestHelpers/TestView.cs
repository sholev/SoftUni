namespace UnitTestsEducationSystem.TestHelpers
{
    using System.Text;

    using EducationSystem.Views;

    public class TestView : View
    {
        public TestView()
            : base(null)
        {
        }

        public string Message { private get; set; }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat(this.Message);
        }
    }
}
