using SportData.Web.Interfaces;

namespace SportData.Web.Services
{
    public abstract class Service
    {
        protected Service(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; }
    }
}