using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Exceptions.Brand
{
    public class BrandExceptionNull:Exception
    {
        public BrandExceptionNull():base("Brand can not be null")
        {

        }
    }
}
