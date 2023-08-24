using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Task<TR> GetResult<TR>(string url);
        Task<TR> PostResult<TR>(string url);
        Task<TR> PostResult<TR>(string url, object content);
        Task<TR> FormPostResult<TR>(string url, Dictionary<string, string> formDictionary);

    }
}
