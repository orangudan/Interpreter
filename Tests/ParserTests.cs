﻿using System.Linq;
using Interpreter.Parsing;
using Interpreter.Parsing.Statements;
using NUnit.Framework;

namespace Tests
{
    public class ParserTests
    {
        private Parser _parser;

        [SetUp]
        public void Set_up_parser()
        {
            _parser = new Parser();
        }

        [Test]
        public void Can_parse_create_variable_statement()
        {
            var script = @"var message = ""seasons greetings""";
            var statement = ParseStatement<CreateVariable>(script);
            Assert.That(statement, Is.TypeOf<CreateVariable>());
            Assert.That(statement.Name, Is.EqualTo("message"));
            Assert.That(statement.Value, Is.EqualTo("seasons greetings"));
        }

        [Test]
        public void Can_parse_assignment_statement()
        {
            var script = @"set message = ""updated""";
            var statement = ParseStatement<Assignment>(script);
            Assert.That(statement, Is.TypeOf<Assignment>());
            Assert.That(statement.Name, Is.EqualTo("message"));
            Assert.That(statement.Value, Is.EqualTo("updated"));
        }

        [Test]
        public void Can_parse_method_call_statement()
        {
            var script = @"print(""hello world"")";
            var statement = ParseStatement<MethodCall>(script);
            Assert.That(statement, Is.TypeOf<MethodCall>());
            Assert.That(statement.Name, Is.EqualTo("print"));
            Assert.That(statement.Arguments.Count, Is.EqualTo(1));
            Assert.That(statement.Arguments.ToList()[0].Value, Is.EqualTo(@"""hello world"""));
        }

        [Test]
        public void Can_parse_if_statement()
        {
            var script = @"if message == ""hello""";
            var statement = ParseStatement<Branch>(script);
            Assert.That(statement, Is.TypeOf<Branch>());
            Assert.That(statement.Left, Is.EqualTo("message"));
            Assert.That(statement.Right, Is.EqualTo(@"""hello"""));
        }

        private T ParseStatement<T>(string script)
        {
            var parseResult = _parser.Parse(script);
            var statement = (T) parseResult.ToList()[0];
            return statement;
        }
    }
}