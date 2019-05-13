using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBookKeeping.Core.Result
{
    public class ErrorResult
    {
        private string _code;
        private string _description;

        public string Code { get => _code; }
        public string Description { get => _description; }

        public ErrorResult(string code, string description)
        {
            _code = code;
            _description = description;
        }
    }
}
