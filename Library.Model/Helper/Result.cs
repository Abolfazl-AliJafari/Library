using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.Helper
{
    public class Result
    {
        protected Result(
            bool success)
        {
            IsSuccess = success;
        }
        protected Result(
    bool success,
    string message)
        {
            IsSuccess = success;
            Message = message;
        }
        /// <summary>
        /// return operation success status 
        /// </summary>
        public bool IsSuccess { get; private set; }
        /// <summary>
        /// return message for operation status
        /// </summary>
        public string Message { get; private set; }



        public static Result Failure() => new Result(false);
        public static Result Failure(string message) => new Result(false,message);

        public static Result Success() => new Result(true);
        public static Result Success(string message) => new Result(true, message);

    }


    public class Result<T> : Result
    {
        protected Result(
            bool issuccess,
            T data)
            :base(issuccess)
        {
            Data = data;
        }
        protected Result(
            bool issuccess,
            string message,
            T data)
            :base(issuccess,message)
        {
            Data = data;
        }

        /// <summary>
        /// return operation data
        /// </summary>
        public T Data { get; private set; }

        public static Result<T> Failure(T data) => new Result<T>(false,data);
        public static Result<T> Failure(string message,T data) => new Result<T>(false,message, data);

        public static Result<T> Success(T data) => new Result<T>(true, data);
        public static Result<T> Success(string message, T data) => new Result<T>(true, message, data);
    }
}
