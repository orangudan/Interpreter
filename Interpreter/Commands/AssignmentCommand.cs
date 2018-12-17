﻿using System.Collections.Generic;
using Interpreter.Token;

namespace Interpreter.Commands
{
    public class AssignmentCommand : CommandBase
    {
        private readonly string _name;
        private readonly string _value;
        private readonly Dictionary<string, StringToken> _scope;

        public AssignmentCommand(
            string name,
            string value,
            IExecutionContext executionContext)
        {
            _name = name;
            _value = value;
            _scope = executionContext.GetCurrentScope();
        }

        public override void Run()
        {
            _scope[_name] = new StringToken(_value);
        }
    }
}
