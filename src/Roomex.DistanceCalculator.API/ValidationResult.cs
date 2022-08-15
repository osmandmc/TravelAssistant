public class ValidationResult{
    public bool Success { get; private set; }
    public List<string> Errors { get; private set; }
    
    public static ValidationResult Successful(){
        return new ValidationResult{ Success = true };
    }
    public static ValidationResult Failure(List<string> errors){
        return new ValidationResult { Success = false, Errors = errors };
    }
    public void Combine(ValidationResult validationResult){
        if(!validationResult.Success){
            Errors.AddRange(validationResult.Errors);
            Success = false;
        }
    }
}