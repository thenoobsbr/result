namespace TheNoobs.Results.Types;

public record BadRequestFail(string Message = "Bad request", string Code = "bad_request") : Fail(Message, Code);
    
public record ValidationFail(string Message = "Validation failed", string Code = "validation_failed") : Fail(Message, Code);
    
public record TimeoutFail(string Message = "Request timed out", string Code = "timeout") : Fail(Message, Code);
    
public record ServerErrorFail(string Message = "Internal server error", string Code = "server_error") : Fail(Message, Code);
    
public record DuplicateResourceFail(string Message = "Duplicate resource found", string Code = "duplicate_resource") : Fail(Message, Code);
    
public record UnauthorizedFail(string Message = "Unauthorized access", string Code = "unauthorized") : Fail(Message, Code);
    
public record UnprocessableEntityFail(string Message = "Unprocessable entity", string Code = "unprocessable_entity") : Fail(Message, Code);
    
public record ConfigurationErrorFail(string Message = "Configuration error", string Code = "config_error") : Fail(Message, Code);
    
public record NotFoundFail(string Message = "Resource not found", string Code = "not_found") : Fail(Message, Code);
    
public record InsufficientPermissionsFail(string Message = "Insufficient permissions", string Code = "insufficient_permissions") : Fail(Message, Code);
    
public record InvalidInputFail(string Message = "Invalid input", string Code = "invalid_input") : Fail(Message, Code);
    
public record DataProcessingFail(string Message = "Error processing data", string Code = "data_processing_error") : Fail(Message, Code);
    
public record ResourceLockedFail(string Message = "Resource is locked", string Code = "resource_locked") : Fail(Message, Code);
    
public record ThirdPartyServiceErrorFail(string Message = "Error from third-party service", string Code = "third_party_error") : Fail(Message, Code);

public record RateLimitExceededFail(string Message = "Rate limit exceeded", string Code = "rate_limit_exceeded") : Fail(Message, Code);

public record AggregateFail(params Fail[] Failures) : Fail("Some failures has occurred", "aggregate_fail");
