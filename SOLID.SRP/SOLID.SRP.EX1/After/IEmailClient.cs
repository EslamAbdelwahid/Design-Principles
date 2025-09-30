using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP.After
{
    public interface IEmailClient
    {
        void Send(Account account, string transactionMessage);
    }
}
