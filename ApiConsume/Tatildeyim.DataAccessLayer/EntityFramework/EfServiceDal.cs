using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatildeyim.DataAccessLayer.Abstract;
using Tatildeyim.DataAccessLayer.Concrete;
using Tatildeyim.DataAccessLayer.Repositories;
using Tatildeyim.EntityLayer.Concrete;

namespace Tatildeyim.DataAccessLayer.EntityFramework
{
    public class EfServiceDal:GenericRepository<Service>,IServiceDal
    {
        public EfServiceDal(Context context) : base(context)
        {

        }

    }
}
