using System;
using System.Collections.Generic;
using System.Text;

namespace ECodeWorld.Domain.Dtos.Core
{
    public class DtoBase : IDto
    {
        private Dictionary<string, string> _brokenRules;
        public bool HasError { get; set; } = false;
        public int Id { get; set; }
        public DtoBase()
        {
            _brokenRules = new Dictionary<string, string>();
        }
        public List<KeyValuePair<string, string>> BrokenRules { get { return this.GetBrokenRules(); } }
        private List<KeyValuePair<string, string>> GetBrokenRules()
        {
            var errors = new List<KeyValuePair<string, string>>();
            foreach (var error in _brokenRules)
                errors.Add(error);
            return errors;
        }
        public virtual void AddRule(string key, string message)
        {
            if (_brokenRules.ContainsKey(key))
                _brokenRules[key] = message;
            else
                _brokenRules.Add(key, message);
        }
    }
}
