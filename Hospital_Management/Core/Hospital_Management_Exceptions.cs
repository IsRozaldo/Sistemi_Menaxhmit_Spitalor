using System;

namespace Hospital_Management.Core
{
    [Serializable]
    public class HospitalManagementException : Exception
    {
        public HospitalManagementException()
        {
        }

        public HospitalManagementException(string message) : base(message)
        {
        }

        public HospitalManagementException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    [Serializable]
    public class ValidationException : HospitalManagementException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    [Serializable]
    public class DuplicateEntryException : HospitalManagementException
    {
        public DuplicateEntryException()
        {
        }

        public DuplicateEntryException(string message) : base(message)
        {
        }

        public DuplicateEntryException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    [Serializable]
    public class NotFoundException : HospitalManagementException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
} 