using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBookKeeping.Core.Result
{
    public class BasicResult<T> where T: class
    {

        private bool _success;
        private T _data;
        private IReadOnlyCollection<ErrorResult> _errors;
        

        public bool Success { get => _success; }
        public T Data { get => _data; }

        public IReadOnlyCollection<ErrorResult> Errors { get => _errors; }
        


        public BasicResult(bool success, T data, IReadOnlyCollection<ErrorResult> errors = null)
        {
            _success = success;
            _errors = errors ?? new List<ErrorResult>();
            _data = data;
        }

    }
}
