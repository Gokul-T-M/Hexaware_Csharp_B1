﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge2.exception
{
    class FileUploadException : Exception
    {
        public FileUploadException(string message) : base(message)
        {
        }
    }
}
