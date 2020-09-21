using Shared.Interfaces;

namespace BackendShared.Test.DataServiceBaseTests.Helpers
{
    public class DataServiceTestModel : IHaveAnId<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}