using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatildeyim.EntityLayer.Concrete;

namespace Tatildeyim.DataAccessLayer.Abstract
{
    public interface ISendMessageDal:IGenericDal<SendMessage>
    {
        public int GetSendMessageCount();
    }
}
