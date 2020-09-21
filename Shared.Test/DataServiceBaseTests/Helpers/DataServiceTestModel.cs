using Shared.Interfaces;

namespace Shared.Test.DataServiceBaseTests.Helpers
{
    public class DataServiceTestModel : IHaveAnId<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}