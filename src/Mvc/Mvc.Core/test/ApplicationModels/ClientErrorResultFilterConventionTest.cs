﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Xunit;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    public class ClientErrorResultFilterConventionTest
    {
        [Fact]
        public void Apply_AddsFilter()
        {
            // Arrange
            var action = GetActionModel();
            var convention = GetConvention();

            // Act
            convention.Apply(action);

            // Assert
            Assert.Single(action.Filters.OfType<ClientErrorResultFilterFactory>());
        }

        private ClientErrorResultFilterConvention GetConvention()
        {
            return new ClientErrorResultFilterConvention();
        }

        private static ActionModel GetActionModel()
        {
            var action = new ActionModel(typeof(object).GetMethods()[0], new object[0]);

            return action;
        }
    }
}
