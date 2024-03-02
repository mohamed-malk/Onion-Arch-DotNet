using Contracts.Department;
using Domain.Enums;
using Mapster;
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

            if (deptObject is null)
                context.Result = new BadRequestObjectResult("Must send an object");
            else if (deptObject.Count == 1)
            {
                try
                {
                    if (!new FiltersService()
                   .DepartmentFilterService
                   .LocationFiler(
                        deptObject.ToList()[0]
                        .Adapt<DepartmenCreatetDto>().Location))
                        context.Result = new
                            BadRequestObjectResult("Location is not valid");
                }
                catch (Exception)
                {
                    context.Result = new
                        BadRequestObjectResult("Object Must Be an DepartmentDto Object");
                }
               
            }   
            else if(deptObject.Count == 2)
            {
                try
                {
                    if (!new FiltersService()
                        .DepartmentFilterService
                        .LocationFiler(
                        deptObject.ToList()[1]
                        .Adapt<Dictionary<Properties, string>>()[Properties.Location]))
                        context.Result = new
                            BadRequestObjectResult("Location is not valid");
                 
                }
                catch (Exception)
                {
                    context.Result = new
                        BadRequestObjectResult("Object Must Be an DepartmentDto Object");
                }

            }
            else
                context.Result = new BadRequestObjectResult("Must send only one object");
                
        }
        catch(Exception ex)
        {
            context.Result = new
                        BadRequestObjectResult(ex);
        }
    }
}