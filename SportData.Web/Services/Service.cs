using SportData.Web.Interfaces;

namespace SportData.Web.Services
{
    public abstract class Service
    {
        protected Service(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }
    }
}