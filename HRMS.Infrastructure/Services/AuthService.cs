using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HRMS.Application.Common;
using HRMS.Application.DTOs;
using HRMS.Application.Interfaces;
using HRMS.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HRMS.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<Guid>> roleManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        // Check if user exists
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);
        if (existingUser != null)
            throw new Exception("User already exists with this email");

        // Create user
        var user = new ApplicationUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            FirstName = dto.FirstName, 
            LastName = dto.LastName,   
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Registration failed: {errors}");
        }

        // Assign role
        if (!await _roleManager.RoleExistsAsync(dto.Role))
            await _roleManager.CreateAsync(new IdentityRole<Guid>(dto.Role));

        await _userManager.AddToRoleAsync(user, dto.Role);

        // Generate token
        return await GenerateTokenAsync(user, dto.Role, dto.FirstName, dto.LastName);
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        // Find user
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            throw new Exception("Invalid email or password");

        // Check password
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!isPasswordValid)
            throw new Exception("Invalid email or password");

        // Check if active
        if (!user.IsActive)
            throw new Exception("Your account is deactivated");

        // Get role
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "Employee";

        // ✅ Pass actual name from user object
        return await GenerateTokenAsync(user, role, user.FirstName, user.LastName);
    }

    private Task<AuthResponseDto> GenerateTokenAsync(
        ApplicationUser user,
        string role,
        string firstName,
        string lastName)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256);

        var expiry = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role),
            new Claim("uid", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiry,
            signingCredentials: credentials);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Task.FromResult(new AuthResponseDto
        {
            Token = tokenString,
            RefreshToken = Guid.NewGuid().ToString(),
            ExpiresAt = expiry,
            Email = user.Email!,
            FullName = $"{firstName} {lastName}".Trim(),
            Role = role
        });
    }
}