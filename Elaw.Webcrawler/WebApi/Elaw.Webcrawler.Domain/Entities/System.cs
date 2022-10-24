using Elaw.Webcrawler.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.Entities;

public class System: BaseEntity
{
    #region ctor
    public System(long id, Guid guid, string code, bool active, DateTime createdAt, DateTime? updatedAt, string name, string? description)
    {
        DomainExceptionValidation.When(id < 0, "ID cannot be less than 0.");
        Id = id;

        ValidateDomain(code, name, description, guid);

        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public System(Guid guid, string code, bool active, DateTime createdAt, DateTime? updatedAt, string name, string? description)
    {
        ValidateDomain(code, name, description, guid);

        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
       
    }
    
    #endregion

    #region entity
    public string Name { get; private set; }
    public string? Description { get; private set; }

    #endregion

    #region validation
    private void ValidateDomain(string code, string name, string? description, Guid guid)
    {

        //code
        if (string.IsNullOrEmpty(code))
            code = DateTime.UtcNow.ToString("ddmmyyMMsshh");
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(code), "Invalid code. code is required");
            DomainExceptionValidation.When(code.Length < 1, "Invalid code, minimum of 1 characters");
            DomainExceptionValidation.When(code.Length > 50, "Invalid code, maximum of 50 characters");
        }

        //name
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. code is required");
        DomainExceptionValidation.When(name.Length < 1, "Invalid name, minimum of 1 characters");
        DomainExceptionValidation.When(name.Length > 200, "Invalid name, maximum of 200 characters");
        //description

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. code is required");
        DomainExceptionValidation.When(description.Length < 1, "Invalid description, minimum of 1 characters");
        DomainExceptionValidation.When(description.Length > 500, "Invalid description, maximum of 500 characters");

        Guid = guid == null ? Guid.NewGuid() : guid;
        Code = code;
        Name = name;
        Description = description;
    }
    #endregion
}
