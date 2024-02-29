using Contracts.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Filters;

namespace Persistence.Filters;

public class DepartmentLocationAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {

        try
        {
            var deptObject = context.ActionArguments.Values;
            DepartmenCreatetDto? department = null;

            if (deptObject is null)
                context.Result = new BadRequestObjectResult("Must send an object");
            else if (deptObject.Count != 1)
                context.Result = new BadRequestObjectResult("Must send only one object");
            else
            {
                try
                {
                    department = (DepartmenCreatetDto)deptObject.FirstOrDefault()!;
                }
                catch (Exception)
                {
                    context.Result = new
                        BadRequestObjectResult("Object Must Be an DepartmentDto Object");
                }
                if (!new FiltersService()
                    .DepartmentFilterService
                    .LocationFiler(department!.Value.Location))
                    context.Result = new
                        BadRequestObjectResult("Location is not valid");

            }
        }
        catch(Exception ex)
        {
            context.Result = new
                        BadRequestObjectResult(ex);
        }
    }
}