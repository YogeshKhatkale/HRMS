namespace HRMS.Application.DTOs;

public class CreateDesignationDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public string? Grade { get; set; }
}

public class UpdateDesignationDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; }
    public string? Grade { get; set; }
    public bool IsActive { get; set; } = true;
}

public class DesignationResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Grade { get; set; }
    public bool IsActive { get; set; }
    public Guid DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int EmployeeCount { get; set; }
    public DateTime CreatedAt { get; set; }
}