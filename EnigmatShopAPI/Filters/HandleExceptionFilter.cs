// using EnigmatShopAPI.Exceptions;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;
//
// namespace EnigmatShopAPI.Filters;
//
// public class HandleExceptionFilter : IExceptionFilter
// {
//     public void OnException(ExceptionContext context)
//     {
//         switch (context.Exception)
//         {
//             case NotFoundException:
//                 context.Result = new NotFoundResult();
//         }
//     }
// }