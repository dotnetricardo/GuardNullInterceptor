using System;
using System.Collections.Generic;
using CodeCop.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GuardNull.CodeCop.UnitTests
{
    [TestClass]
    public class GuardNullInterceptorTests
    {
        [TestMethod]
        public void GuardNullShouldThrowArgumentNullExceptionWhenArgumentIsNull()
        {
            // Arrange
            var gni = new GuardNullInterceptor();
            var context = new InterceptionContext
            {
                Parameters = new List<Parameter> {new Parameter() {Name = "Dummy", Value = null}}
            };

            // Act & Assert
            gni.Invoking(x => gni.OnBeforeExecute(context)).ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void GuardNullShouldThrowArgumentNullExceptionWhenArgumentTypeIsStringAndIsEmpty()
        {
            // Arrange
            var gni = new GuardNullInterceptor();
            var context = new InterceptionContext
            {
                Parameters = new List<Parameter> {new Parameter() {Name = "Dummy", Value = ""}}
            };

            // Act & Assert
            gni.Invoking(x => gni.OnBeforeExecute(context)).ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void GuardNullShouldNotThrowArgumentNullExceptionWhenParameterIsOptional()
        {
            // Arrange
            var gni = new GuardNullInterceptor();
            var context = new InterceptionContext
            {
                Parameters = new List<Parameter> {new Parameter() {Name = "Dummy", Value = null, IsOptional = true}}
            };

            // Act & Assert
            gni.Invoking(x => gni.OnBeforeExecute(context)).ShouldNotThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void GuardNullShouldThrowArgumentNullExceptionWhenFirstParameterIsNullAndHasOptionalParameter()
        {
            // Arrange
            var gni = new GuardNullInterceptor();
            var context = new InterceptionContext
            {
                Parameters = new List<Parameter> { new Parameter() { Name = "Dummy", Value = null}, new Parameter() { Name = "Dummy2", Value = null, IsOptional = true } }
            };

            // Act & Assert
            gni.Invoking(x => gni.OnBeforeExecute(context)).ShouldThrow<ArgumentNullException>();

        }
    }
}
