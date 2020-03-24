using System;
using System.Collections.Generic;
using System.Text;
/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace Integration.Storm.Managers
{
    public interface IStormConnectionManager
    {
        TR GetResult<TR>(string url);
        TR PostResult<TR>(string url);
        TR PostResult<TR>(string url, object content);
        TR FormPostResult<TR>(string url, Dictionary<string, string> formDictionary);

    }
}
