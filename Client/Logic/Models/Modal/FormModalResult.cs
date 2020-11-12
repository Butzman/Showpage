namespace BlazorClient.Logic.Models.Modal
{
    public class FormModalResult<TModel>
    {
        public bool IsSuccess { get; set; }
        public TModel Result { get; set; }
    }
}