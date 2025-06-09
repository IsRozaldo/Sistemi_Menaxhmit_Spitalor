using System;

namespace Hospital_Management.Core
{
    [Serializable]
    public class HospitalManagementException : Exception
    {
        public string ErrorCode { get; }
        public DateTime Timestamp { get; }

        public HospitalManagementException()
        {
            Timestamp = DateTime.UtcNow;
        }

        public HospitalManagementException(string message) : base(message)
        {
            Timestamp = DateTime.UtcNow;
        }

        public HospitalManagementException(string message, Exception inner) : base(message, inner)
        {
            Timestamp = DateTime.UtcNow;
        }

        public HospitalManagementException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
            Timestamp = DateTime.UtcNow;
        }
    }

    [Serializable]
    public class ValidationException : HospitalManagementException
    {
        public string PropertyName { get; }
        public object AttemptedValue { get; }

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        public ValidationException(string propertyName, object attemptedValue, string message) 
            : base(message)
        {
            PropertyName = propertyName;
            AttemptedValue = attemptedValue;
        }
    }

    [Serializable]
    public class DuplicateEntryException : HospitalManagementException
    {
        public string EntityName { get; }
        public object KeyValue { get; }

        public DuplicateEntryException()
        {
        }

        public DuplicateEntryException(string message) : base(message)
        {
        }

        public DuplicateEntryException(string message, Exception inner) : base(message, inner)
        {
        }

        public DuplicateEntryException(string entityName, object keyValue, string message) 
            : base(message)
        {
            EntityName = entityName;
            KeyValue = keyValue;
        }
    }

    [Serializable]
    public class NotFoundException : HospitalManagementException
    {
        public string EntityName { get; }
        public object KeyValue { get; }

        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        public NotFoundException(string entityName, object keyValue, string message) 
            : base(message)
        {
            EntityName = entityName;
            KeyValue = keyValue;
        }
    }

    [Serializable]
    public class DatabaseException : HospitalManagementException
    {
        public string Operation { get; }

        public DatabaseException(string message) : base(message)
        {
        }

        public DatabaseException(string message, Exception inner) : base(message, inner)
        {
        }

        public DatabaseException(string operation, string message) : base(message)
        {
            Operation = operation;
        }

        public DatabaseException(string operation, string message, Exception inner) : base(message, inner)
        {
            Operation = operation;
        }
    }

    [Serializable]
    public class AuthenticationException : HospitalManagementException
    {
        public string Username { get; }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string username, string message) : base(message)
        {
            Username = username;
        }
    }

    [Serializable]
    public class AuthorizationException : HospitalManagementException
    {
        public string RequiredRole { get; }
        public string UserRole { get; }

        public AuthorizationException(string message) : base(message)
        {
        }

        public AuthorizationException(string requiredRole, string userRole, string message) 
            : base(message)
        {
            RequiredRole = requiredRole;
            UserRole = userRole;
        }
    }

    [Serializable]
    public class BusinessRuleException : HospitalManagementException
    {
        public string RuleName { get; }

        public BusinessRuleException(string message) : base(message)
        {
        }

        public BusinessRuleException(string ruleName, string message) : base(message)
        {
            RuleName = ruleName;
        }
    }
} 