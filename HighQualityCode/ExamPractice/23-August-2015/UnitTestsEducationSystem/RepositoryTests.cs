// R# doesn't like them fancy underscore names ;(
// ReSharper disable InconsistentNaming
namespace UnitTestsEducationSystem
{
    using System.Collections.Generic;

    using EducationSystem.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        private Repository<string> repo;

        private string[] repoMaterials;

        [TestInitialize]
        public void InitializeTestData()
        {
            this.repo = new Repository<string>();
            this.repoMaterials = new[] { "firstElement", "secondElement", "luckyElement" };
        }

        [TestMethod]
        public void EmptyRepository_Get_ReturnsDefault()
        {
            var element = this.repo.Get(7);

            Assert.AreEqual(default(string), element, "Invalid default return type on Repository.Get");
        }

        [TestMethod]
        public void NonEmptyRepository_Get_ReturnsElement()
        {
            this.AddElementsToRepo(this.repo, this.repoMaterials);
            var element = this.repo.Get(3);

            Assert.AreEqual(this.repoMaterials[2], element, "Repository.Get does not return proper element.");
        }

        private void AddElementsToRepo<T>(Repository<T> repository, IEnumerable<T> elements)
        {
            foreach (T element in elements)
            {
                repository.Add(element);
            }
        }
    }
}
