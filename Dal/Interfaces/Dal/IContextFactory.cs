using Microsoft.EntityFrameworkCore;

namespace Dal.Interfaces.Dal
{
    public interface IContextFactory
    {
        DalContext CreateContext();
    }
}