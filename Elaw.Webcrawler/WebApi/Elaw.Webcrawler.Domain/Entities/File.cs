using Elaw.Webcrawler.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.Entities;

public class File: BaseEntity
{
    #region ctor
    public File(long id, long idExecution, Guid guid, string code, string name, string package, Int16? linesNumber, bool active, DateTime createdAt, DateTime? updatedAt)
    {
        DomainExceptionValidation.When(id < 0, "ID cannot be less than 0.");
        Id = id;

        DomainExceptionValidation.When(idExecution < 0, "idExecution cannot be less than 0.");
        IdExecution = idExecution;

        ValidateDomain(code, Name, package, guid);
        
        LinesNumber = linesNumber;
        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public File(long idExecution, Guid guid, string code, string name, string package, Int16? linesNumber, bool active, DateTime createdAt, DateTime? updatedAt)
    {
        DomainExceptionValidation.When(idExecution < 0, "idExecution cannot be less than 0.");
        IdExecution = idExecution;

        ValidateDomain(code, name, package, guid);

        LinesNumber = linesNumber;
        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    #endregion

    #region entity
    public long IdExecution { get; set; }
    public string Name { get; set; } = null!;
    public string Package { get; set; } = null!;
    public Int16? LinesNumber { get; set; }

    #endregion

    #region validation
    private void ValidateDomain(string code, string name, string package, Guid guid)
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
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid description. code is required");
        DomainExceptionValidation.When(name.Length < 1, "Invalid description, minimum of 1 characters");
        DomainExceptionValidation.When(name.Length > 200, "Invalid description, maximum of 200 characters");
        //package
        DomainExceptionValidation.When(string.IsNullOrEmpty(package), "Invalid package. code is required");


        Guid = Guid.NewGuid();
        Code = code;
        Name = name;
        Package = package;
    }
    #endregion
}
