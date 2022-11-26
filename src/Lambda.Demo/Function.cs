using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Lambda.Demo
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            context.Logger.LogLine($"Got new message: {input} - Request-Id:{ context.AwsRequestId}");
            context.Logger.LogLine($"LogStreamName:: {context.LogStreamName}"); 
            context.Logger.LogLine($"LogGroupName:: {context.LogGroupName}");
            context.Logger.LogLine($"MemoryLimitInMB:: {context.MemoryLimitInMB}");

            return input?.ToUpper();
        }
    }
}
