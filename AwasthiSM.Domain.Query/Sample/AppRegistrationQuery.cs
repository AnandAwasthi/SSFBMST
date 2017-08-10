using AwasthiSM.Model.ApiManagement;
using AwasthiSM.Mongo.Generic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwasthiSM.Domain.Query.ApiManagment
{
    public class AppRegistrationQuery : Reposistory<AppRegistration>, IAppRegistrationQuery
    {
        public AppRegistrationQuery()
        {

        }

        public IEnumerable<AppRegistration> GetAppRegistrations()
        {
            return this.collection.AsQueryable<AppRegistration>().GetEnumerator();
        }
    }
    public interface IAppRegistrationQuery
    {
        IEnumerable<AppRegistration> GetAppRegistrations();
    }

    public class AppRegistration : Entity { }
}
