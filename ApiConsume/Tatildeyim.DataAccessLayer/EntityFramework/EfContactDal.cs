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
    public class EfContactDal:GenericRepository<Contact>,IContactDal
    {
        public EfContactDal(Context context):base(context)
        {

        }

        public int GetContactCount()
        {
            var context = new Context();
            return context.Contacts.Count();
        }
    }
}
