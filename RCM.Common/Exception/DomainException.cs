using System;
using System.Collections.Generic;
using System.Text;

namespace RCM.Common.Exception
{
    public abstract class DomainException :SystemException
    {
        public DomainException(string message) : base(message)
        {

        }
    }

    public class DomainNotFoundException: DomainException
    {
        public  DomainNotFoundException(string message):base(message)
        {

        }
    }


    public class DomainValidationException:DomainException
    {
        public DomainValidationException(string message) : base(message)
        {

        }
    }
}
