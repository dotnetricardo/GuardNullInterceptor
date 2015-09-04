# GuardNullInterceptor 
Interceptor for use with CodeCop (http://getcodecop.com) that validates if any non-optional method arguments are not null, or in case of strings also not empty.

# Instructions
To place this Interceptor on all intercepted methods, just insert "GuardNullInterceptor" in the GlobalInterceptors array of your copconfig.json file, like so:

```
{
    "Types": [
        {
            "TypeName": "ConsoleApplication1.FooClass, ConsoleApplication1",
            "Methods": [
                {
                    "MethodSignature": "FooMethod1(System.Object, System.String)",
                    "Interceptors": [ ]
                },
                {
                    "MethodSignature": "FooMethod2(System.String)",
                    "Interceptors": [ ]
                }
            ],
          "GenericArgumentTypes": [ ]
        }
    ],
    "GlobalInterceptors": ["GuardNullInterceptor"],
    "Key":"Your product key or leave empty for free product mode"

}
```
