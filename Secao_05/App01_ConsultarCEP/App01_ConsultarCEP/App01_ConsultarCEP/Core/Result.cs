using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Core
{
    public class Result
    {
        public string StackTrace { get; set; }

        public string Message { get; set; }

        public bool Sucess
        {
            get
            {
                return string.IsNullOrEmpty(Message);
            }
        }

        public Result()
        {

        }

        public Result(string message)
        {
            this.Message = message;
        }

        public Result(Exception ex)
        {
            this.Message = ex.Message;
            this.StackTrace = ex.StackTrace;
        }
    }
}
