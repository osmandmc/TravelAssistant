public class ValidationResult{
    public bool Success { get; private set; }
    public List<string> Errors { get; private set; }
    
    private ValidationResult(){
        Success = true;
        Errors = new List<string>();
    }
    private ValidationResult(List<string> errors){
        Success = false;
        Errors = errors;
    }
    public static ValidationResult Successful(){
        return new ValidationResult();
    }
    public static ValidationResult Failure(List<string> errors){
        return new ValidationResult(errors);
    }
    public void Combine(ValidationResult validationResult){
        if(!validationResult.Success){
            Errors.AddRange(validationResult.Errors);
            Success = false;
        }
    }
}