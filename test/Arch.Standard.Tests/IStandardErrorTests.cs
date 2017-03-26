// Copyright (c) Arch team of Tencent. All rights reserved.

using System;
using System.Linq;
using Xunit;
using Newtonsoft.Json;

namespace Arch.Standard.Tests
{
    public class IStandardErrorTests
    {
        [Fact]
        public void IStandardError_Target_IsCallerMemberName_Test()
        {
            var error = StandardException.Caused("Code", "xUnit");

            Assert.Equal(nameof(IStandardError_Target_IsCallerMemberName_Test), error.Target);
            Assert.Equal("xUnit", error.Message);
        }

        [Fact]
        public void IStandardError_Fluent_API_Feature_Test()
        {
            Assert.Throws<StandardException>(() => {
                StandardException.Caused("Code", "xunit").Append(StandardException.Caused("InnerCode", "details")).Throw();
            });
        }

        [Fact]
        public void IStandardError_Can_Json_Serialize_Test()
        {
            var exception = StandardException.Caused("Code", "xunit").Append(StandardException.Caused("InnerCode", "details", "InnerTarget"));

            var json = JsonConvert.SerializeObject(exception);

            Assert.False(string.IsNullOrEmpty(json));
        }
    }
}
