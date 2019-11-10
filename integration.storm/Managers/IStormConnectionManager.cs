using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Storm.Managers
{
    public interface IStormConnectionManager
    {
        TR GetResult<TR>(string url);
        TR PostResult<TR>(string url);
        TR PostResult<TR>(string url, object content);

    }
}
