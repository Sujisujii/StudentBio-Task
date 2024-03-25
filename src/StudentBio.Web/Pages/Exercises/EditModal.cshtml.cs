using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using StudentBio.Exercises;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace StudentBio.Web.Pages.Exercises;

public class EditModalModel : StudentBioPageModel
{
    [BindProperty]
    public EditExerciseViewModel Exercise { get; set; }

    private readonly IExerciseAppService _exerciseAppService;

    public EditModalModel(IExerciseAppService exerciseAppService)
    {
        _exerciseAppService = exerciseAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var exerciseDto = await _exerciseAppService.GetAsync(id);
        Exercise = ObjectMapper.Map<ExerciseDto, EditExerciseViewModel>(exerciseDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _exerciseAppService.UpdateAsync(
            Exercise.Id,
            ObjectMapper.Map<EditExerciseViewModel, UpdateExerciseDto>(Exercise)
        );

        return NoContent();
    }

    public class EditExerciseViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [Required]
        public int StudentExerciseId { get; set; }
        [Required]
        [StringLength(ExerciseConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Required]

        public bool IsCompleted{ get; set; }
    }
}
