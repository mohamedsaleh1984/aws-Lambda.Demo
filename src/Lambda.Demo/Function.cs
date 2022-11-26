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

/*
 
 Deployment to AWS Reults
--------------------------
PS D:\repo\Lambda.Demo\src\Lambda.Demo> dotnet lambda deploy-function LambdaDemo
Amazon Lambda Tools for .NET Core applications (5.6.2)
Project Home: https://github.com/aws/aws-extensions-for-dotnet-cli, https://github.com/aws/aws-lambda-dotnet

Executing publish command
... invoking 'dotnet publish', working folder 'D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\publish'
... dotnet publish "D:\repo\Lambda.Demo\src\Lambda.Demo" --output "D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\publish" --configuration "Release" --framework "netcoreapp3.1" /p:GenerateRuntimeConfigurationFiles=true --runtime linux-x64 --self-contained False
... publish: MSBuild version 17.3.2+561848881 for .NET
... publish:   Determining projects to restore...
... publish:   All projects are up-to-date for restore.
... publish:   Lambda.Demo -> D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\linux-x64\Lambda.Demo.dll
... publish:   Lambda.Demo -> D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\publish\
Zipping publish folder D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\publish to D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\Lambda.Demo.zip
... zipping: Amazon.Lambda.Core.dll
... zipping: Amazon.Lambda.Serialization.SystemTextJson.dll
... zipping: Lambda.Demo.deps.json
... zipping: Lambda.Demo.dll
... zipping: Lambda.Demo.pdb
... zipping: Lambda.Demo.runtimeconfig.json
Created publish archive (D:\repo\Lambda.Demo\src\Lambda.Demo\bin\Release\netcoreapp3.1\Lambda.Demo.zip).
Updating code for existing function LambdaDemo

 */