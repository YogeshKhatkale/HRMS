namespace HRMS.Application.DTOs;

public class CreateDepartmentDto
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid? ParentDeptId { get; set; }
    public Guid? ManagerId { get; set; }
    public string? Description { get; set; }
}

public class UpdateDepartmentDto
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public Guid? ParentDeptId { get; set; }
    public Guid? ManagerId { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}

public class DepartmentResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentDeptId { get; set; }
    public string? ParentDepartmentName { get; set; }
    public string? ManagerName { get; set; }
    public int EmployeeCount { get; set; }
    public DateTime CreatedAt { get; set; }
}