namespace TheNoobs.Results.Types;

public record BadRequestFail(string message = "Bad request", string code = "bad_request") : Fail(message, code);
    
public record ValidationFail(string message = "Validation failed", string code = "validation_failed") : Fail(message, code);
    
public record TimeoutFail(string message = "Request timed out", string code = "timeout") : Fail(message, code);
    
public record ServerErrorFail(string message = "Internal server error", string code = "server_error") : Fail(message, code);
    
public record DuplicateResourceFail(string message = "Duplicate resource found", string code = "duplicate_resource") : Fail(message, code);
    
public record UnauthorizedFail(string message = "Unauthorized access", string code = "unauthorized") : Fail(message, code);
    
public record UnprocessableEntityFail(string message = "Unprocessable entity", string code = "unprocessable_entity") : Fail(message, code);
    
public record ConfigurationErrorFail(string message = "Configuration error", string code = "config_error") : Fail(message, code);
    
public record NotFoundFail(string message = "Resource not found", string code = "not_found") : Fail(message, code);
    
public record InsufficientPermissionsFail(string message = "Insufficient permissions", string code = "insufficient_permissions") : Fail(message, code);
    
public record InvalidInputFail(string message = "Invalid input", string code = "invalid_input") : Fail(message, code);
    
public record DataProcessingFail(string message = "Error processing data", string code = "data_processing_error") : Fail(message, code);
    
public record ResourceLockedFail(string message = "Resource is locked", string code = "resource_locked") : Fail(message, code);
    
public record ThirdPartyServiceErrorFail(string message = "Error from third-party service", string code = "third_party_error") : Fail(message, code);

public record RateLimitExceededFail(string message = "Rate limit exceeded", string code = "rate_limit_exceeded") : Fail(message, code);
