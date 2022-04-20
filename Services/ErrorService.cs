using Newtonsoft.Json;
using System;

namespace TestAPI.Services
{
    public class ErrorService
    {

        public Errors _errors;

        public ErrorService()
        {
            string json = File.ReadAllText("JSON_Configs/Errors.json");
            _errors = JsonConvert.DeserializeObject<Errors>(json);
        }

        public List<Error> GetErrors()
        {
            return _errors.errors;
        }

        public Error GetError(string errCode)
        {
            return _errors.errors.Find(item => item.ErrorCode.Equals(errCode));
        }

    }

    public class Errors
    {
        public List<Error> errors { get; set; } = new List<Error>();
    }
}