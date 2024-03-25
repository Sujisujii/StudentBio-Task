using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StudentBio.Students;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace StudentBio.Web.Pages.Students;

public class EditModalModel : StudentBioPageModel
{
    [BindProperty]
    public EditStudentViewModel Student { get; set; }

    public List<SelectListItem> Exercises { get; set; }

    private readonly IStudentAppService _studentAppService;

    public EditModalModel(IStudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var studentDto = await _studentAppService.GetAsync(id);
        Student = ObjectMapper.Map<StudentDto, EditStudentViewModel>(studentDto);

        var exerciseLookup = await _studentAppService.GetExerciseLookupAsync();
        Exercises = exerciseLookup.Items
            .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _studentAppService.UpdateAsync(
            Student.Id,
            ObjectMapper.Map<EditStudentViewModel, CreateUpdateStudentDto>(Student)
        );

        return NoContent();
    }

    public class EditStudentViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [SelectItems(nameof(Exercises))]
        [DisplayName("Exercise")]
        public Guid ExerciseId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int ClassStudentId { get; set; }
      
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Required]
        public ClassStudentExercise ClassExercise { get; set; } = ClassStudentExercise.Undefined;


    }
}
