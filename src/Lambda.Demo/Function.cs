using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Lambda.Demo
{
    /*
    
    Install dotnet amazon lambda tools
    C:\Users\Moham>dotnet tool install -g Amazon.Lambda.Tools

    Install Amazon Lambda Function Template Projects
    dotnet new --install Amazon.Lambda.Templates::5.2.0

    Create New Lambda Function application
    dotnet new lambda.EmptyFunction --name Lambda.Demo

    Deploy Lambda Function to Aws
    dotnet lambda deploy-function LambdaDemo

    */
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
