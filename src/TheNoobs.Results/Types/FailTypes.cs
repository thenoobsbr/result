using TheNoobs.Results.Abstractions;

namespace TheNoobs.Results.Types;

public record BadRequestFail(string Message = "Bad request", string Code = "bad_request", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record ValidationFail(string Message = "Validation failed", string Code = "validation_failed", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record TimeoutFail(string Message = "Request timed out", string Code = "timeout", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record ServerErrorFail(string Message = "Internal server error", string Code = "server_error", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record DuplicateResourceFail(string Message = "Duplicate resource found", string Code = "duplicate_resource", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record UnauthorizedFail(string Message = "Unauthorized access", string Code = "unauthorized", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record UnprocessableEntityFail(string Message = "Unprocessable entity", string Code = "unprocessable_entity", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record ConfigurationErrorFail(string Message = "Configuration error", string Code = "config_error", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record NotFoundFail(string Message = "Resource not found", string Code = "not_found", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record InsufficientPermissionsFail(string Message = "Insufficient permissions", string Code = "insufficient_permissions", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record InvalidInputFail(string Message = "Invalid input", string Code = "invalid_input", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record DataProcessingFail(string Message = "Error processing data", string Code = "data_processing_error", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record ResourceLockedFail(string Message = "Resource is locked", string Code = "resource_locked", Exception? Exception = null) : Fail(Message, Code, Exception);
    
public record ThirdPartyServiceErrorFail(string Message = "Error from third-party service", string Code = "third_party_error", Exception? Exception = null) : Fail(Message, Code, Exception);

public record RateLimitExceededFail(string Message = "Rate limit exceeded", string Code = "rate_limit_exceeded", Exception? Exception = null) : Fail(Message, Code, Exception);
