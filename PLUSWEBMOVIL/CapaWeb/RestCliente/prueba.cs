using CapaWeb.RestCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaWeb.RestCliente
{

    public class Args
    {
    }

    public class Files
    {
    }

    public class Form
    {
    }

    public class Headers
    {
        public string Authorization { get; set; }
        public string __invalid_name__Content_Length { get; set; }
    public string __invalid_name__Content_Type { get; set; }
public string Host { get; set; }
}

public class RootObject
{
    public Args args { get; set; }
    public string data { get; set; }
    public Files files { get; set; }
    public Form form { get; set; }
    public Headers headers { get; set; }
    public string json { get; set; }
    public string origin { get; set; }
    public string url { get; set; }
}
}
