using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiangMu.API.Models
{
    //客户表
    public class Client
    {
        public Guid ID       { get; set; }
        public string CName    { get; set; }
        public string CPhone   { get; set; }
        public string CImag    { get; set; }
        public int CTime    { get; set; }
        public string CAccount { get; set; }
        public string Cpwd     { get; set; }
    }
}