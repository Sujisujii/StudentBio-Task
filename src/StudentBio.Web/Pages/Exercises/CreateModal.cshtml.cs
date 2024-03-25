using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using StudentBio.Exercises;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace StudentBio.Web.Pages.Exercises;

public class CreateModalModel : StudentBioPageModel
{
    [BindProperty]
    public CreateExerciseViewModel Exercise { get; set; }

    private readonly IExerciseAppService _exerciseAppService;

    public CreateModalModel(IExerciseAppService exerciseAppService)
    {
        _exerciseAppService = exerciseAppService;
    }

    public void OnGet()
    {
        Exercise = new CreateExerciseViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateExerciseViewModel, CreateExerciseDto>(Exercise);
        await _exerciseAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateExerciseViewModel
    {
        [Required]
        public int StudentExerciseId { get; set; }
        [Required]
        [StringLength(ExerciseConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        
        [Required]
        public bool IsCompleted { get; set; }
    }
}
