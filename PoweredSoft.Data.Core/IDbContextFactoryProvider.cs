using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Data.Core
{
    public interface IDbContextFactoryProvider
    {
        IDbContextFactory GetContextFactory(Type contextType);
    }
}
