namespace Common.Models
{
    /// <summary>
    /// An user representation.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// User full name (Or nickname)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User e-mail.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User mobile number.
        /// </summary>
        public long PhoneNumber { get; set; }
        /// <summary>
        /// Area code for the user phone number.
        /// </summary>
        public int AreaCodePhoneNumber { get; set; }
        /// <summary>
        /// User hashed password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// User hashed password confirmation.
        /// </summary>
        public string PasswordConfirmation { get; set; }

        /// <summary>
        /// User device of origin.
        /// </summary>
        public string UserOriginalAgent { get; set; }

        /// <summary>
        /// User last agent.
        /// </summary>
        public string UserLastAgent { get; set; }
    }
}
