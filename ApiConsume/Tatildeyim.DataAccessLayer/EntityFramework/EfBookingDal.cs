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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context):base(context)
        {

        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandı";
            context.SaveChanges();
        }
    }
}
