using learngate_api.Contracts;
using learngate_api.DTOs;
using learngate_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace learngate_api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public AuthController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository
            )
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }



         
        [HttpPost]
        [Route("studentRegister")]

        public async Task<IActionResult> RegisterStudent([FromBody] StudentRegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        if(registerRequestDto.Roles.Any(x => x.Equals("Student", StringComparison.OrdinalIgnoreCase)))
                        {
                            var student = new Student
                            {
                                UserName = registerRequestDto.Username,
                                Name = registerRequestDto.Name,
                                Surname = registerRequestDto.Surname,
                                Email = registerRequestDto.Email,
                                Phone = registerRequestDto.Phone,
                                Address = registerRequestDto.Address,
                                Img = registerRequestDto.Img,
                                BloodType = registerRequestDto.BloodType,
                                GradeId = registerRequestDto.GradeId,
                                Sex = registerRequestDto.Sex,
                                ParentId = registerRequestDto.ParentId,
                                ClassId = registerRequestDto.ClassId,
                            };
                            await _studentRepository.CreateStudentAsync(student);
                        }

                        return Ok(new { message = "User was registered.Please log in" });
                    }

                }

            }
            return BadRequest(new { message = "something went wrong" });

        }


        [HttpPost]
        [Route("teacherRegister")]

        public async Task<IActionResult> RegisterTeacher([FromBody] TeacherRegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                            var teacher = new Teacher
                            {
                                UserName = registerRequestDto.Username,
                                Name = registerRequestDto.Name,
                                Surname = registerRequestDto.Surname,
                                Email = registerRequestDto.Email,
                                Phone = registerRequestDto.Phone,
                                Address = registerRequestDto.Address,
                                Img = registerRequestDto.Img,
                                BloodType = registerRequestDto.BloodType,
                                Sex = registerRequestDto.Sex,
                                TeacherSubjects = new List<TeacherSubject>(),
                            };
                            await _teacherRepository.CreateTeacherAsync(teacher, registerRequestDto.SubjectIds);
                            return Ok(new { message = "User was registered.Please log in" });
                    }

                }

            }
            return BadRequest(new { message = "something went wrong" });

        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user != null) 
            {
               var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                   var roles = await _userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };
                        return Ok(response);
                    }
                }
            }

            return BadRequest("Usename or password incorrect");
        }
    }
}
