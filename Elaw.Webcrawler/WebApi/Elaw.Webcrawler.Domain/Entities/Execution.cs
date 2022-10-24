using Elaw.Webcrawler.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Domain.Entities;

public class Execution: BaseEntity
{
    #region ctor
    public Execution(long id, long idSystem, Guid guid, string code, DateTime startDate, DateTime? endDate, Int16? pagesNumber, bool active, DateTime createdAt, DateTime? updatedAt)
    {
        DomainExceptionValidation.When(id < 0, "ID cannot be less than 0.");
        Id = id;

        DomainExceptionValidation.When(idSystem < 0, "IdSystem cannot be less than 0.");
        IdSystem = idSystem;

        ValidateDomain(code, guid);

        StartDate = startDate;
        EndDate = endDate;
        PagesNumber = pagesNumber;
        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Execution(long idSystem, Guid guid, string code, DateTime startDate, DateTime? endDate, Int16? pagesNumber, bool active, DateTime createdAt, DateTime? updatedAt)
    {
        DomainExceptionValidation.When(idSystem < 0, "IdSystem cannot be less than 0.");
        IdSystem = idSystem;

        ValidateDomain(code, guid);

        StartDate = startDate;
        EndDate = endDate;
        PagesNumber = pagesNumber;
        Active = active;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    #endregion

    #region entity
    public long IdSystem { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Int16? PagesNumber { get; set; }
    #endregion

    #region validation
    private void ValidateDomain(string code,Guid guid)
    {

        //code
        if (string.IsNullOrEmpty(code))
            code = DateTime.UtcNow.ToString("ddmmyyMMsshh");
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(code), "Invalid code. code is required");
            DomainExceptionValidation.When(code.Length < 1, "Invalid code, minimum of 1 characters");
            DomainExceptionValidation.When(code.Length > 50, "Invalid code, maximum of 50 characters");
        }

        Guid = Guid.NewGuid();
        Code = code;
    }
    #endregion

    public void Update(Guid guid, DateTime? endDate, bool active, DateTime? updatedAt)
    {
        Guid = guid;
        EndDate = endDate;
        Active = active;
        UpdatedAt = updatedAt;
    }
}
