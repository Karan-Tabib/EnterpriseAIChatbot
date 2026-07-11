namespace EnterpriseAI.Api.Middleware
{
    public static class StatusCodeExtenstion{

        public static (int,string) GetStatusCode(Exception ex)
        {
            switch (ex.GetType()) 
            {
                case ValidationException:
                    {
                        return (StatusCodes.Status400BadRequest,"Bad Request");
                    }
                case NotFoundException:
                    {
                        return (StatusCodes.Status404NotFound," Not Found");
                    }
                case ConflictException:
                    {
                        return (StatusCodes.Status409Conflict,"Conflict occurred");
                    }
                case BusinessRuleException:
                    {
                        return (StatusCodes.Status422UnprocessableEntity,"can process Entity");
                    }
                case UnauthorizedException:
                    {
                        return (StatusCodes.Status401Unauthorized,"Unauthorized access");
                    }
                default:
                    {
                        return (StatusCodes.Status500InternalServerError,"Internal Server errror");
                    }
                    
               
            }
        }
    }
}
