using System;
namespace TwitterAPI.Models
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}

/// DTO (Data Transfer Object) ... just has data and nothing else .... way to pass data around application or 
/// pass a structure around ..
/// want to be able to instansiate an object of this class and give it some values .. data transfer .. transfer data around your app 
/// 
///  plain old .. object or class that doesn't have any methods just attributes 
