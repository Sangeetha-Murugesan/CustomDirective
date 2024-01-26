using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace IgnoreInputValidation
{

    [DirectiveType(DirectiveLocation.Schema | DirectiveLocation.ArgumentDefinition)]
    [InputValidationMiddleware]
    public class ValidateInput
    {

    }

    public class InputValidationAttribute : ArgumentDescriptorAttribute
    {
        protected override void OnConfigure(IDescriptorContext context, IArgumentDescriptor descriptor, ParameterInfo parameter)
        {
            descriptor.Directive(new ValidateInput());
        }
    }

    public class InputValidationMiddlewareAttribute : DirectiveTypeDescriptorAttribute
    {
        protected override void OnConfigure(IDescriptorContext context, IDirectiveTypeDescriptor descriptor, Type type)
        {
            descriptor.Use((next, directive) =>
            {
                Console.WriteLine("InputRequiredMiddlewareAttribute");
                var dir = directive.AsValue<ValidateInput>();
                //if () { }
                //else
                return async context =>
                {
                    context.ReportError("Input Validation failed");
                };
            });
        }
    }
}
