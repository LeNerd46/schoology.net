using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoology.Entities
{
    public class User
    {
        /// <summary>
        /// The internal Schoology ID of the user
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// The interal Schoology ID of the school to which the user belongs
        /// </summary>
        [JsonProperty("school_id")]
        public string SchoolID { get; set; }

        /// <summary>
        /// The internal Schoology ID of the school building to which the user belongs
        /// </summary>
        [JsonProperty("building_id")]
        public string BuildingID { get; set; }

        /// <summary>
        /// The user's unique ID, requires admin
        /// </summary>
        [JsonProperty("school_uid")]
        public string SchoolUID { get; set; }

        /*/// <summary>
        /// The user's title
        /// </summary>
        [JsonProperty("name_title")]
        public NameTitle Title { get; set; }*/

        /// <summary>
        /// Whether to show the user's tilte when displaying his/her full name
        /// </summary>
        [JsonProperty("name_title_show")]
        public bool ShowNameTitle { get; set; }

        /// <summary>
        /// THe user's first name
        /// </summary>
        [JsonProperty("name_first")]
        public string FirstName { get; set; }

        /// <summary>
        /// The name by which the user goes
        /// </summary>
        [JsonProperty("name_first_preferred")]
        public string PreferredFirstName { get; set; }

        /// <summary>
        /// The user's middle name
        /// </summary>
        [JsonProperty("name_middle")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Whether to show the user's middle name when displaying his/her full name
        /// </summary>
        [JsonProperty("name_middle_show")]
        public string ShowMiddleName { get; set; }

        /// <summary>
        /// The user's last name
        /// </summary>
        [JsonProperty("name_last")]
        public string LastName { get; set; }

        // Display name, type no?

        /// <summary>
        /// The user's username (either a username or email address is required for each user), requires admin
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// The user's primary email address (either a username or email address is required for each user)
        /// </summary>
        [JsonProperty("primary_email")]
        public string Email { get; set; }

        /// <summary>
        /// The user's position in the school/company
        /// </summary>
        [JsonProperty("position")]
        public string JobPosition { get; set; }

        /*/// <summary>
        /// The user's gender
        /// </summary>
        public Gender Gender { get; set; }*/

        /// <summary>
        /// The user's graduation year, requires admin
        /// </summary>
        [JsonProperty("grad_year")]
        public int GraduationYear { get; set; }

        /// <summary>
        /// The user's birthday
        /// </summary>
        [JsonProperty("birthday_date")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// The user's password, requires admin
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The ID of the role to which you would like to assign the user, requires admin
        /// </summary>
        [JsonProperty("role_id")]
        public int RoleID { get; set; }

        /// <summary>
        /// Whether to send login information by email, used only during user creation
        /// </summary>
        [JsonProperty("email_login_info")]
        public bool EmailLoginInformation { get; set; }

        /// <summary>
        /// The full URL of the user's profile picture
        /// </summary>
        [JsonProperty("profile_url")]
        public string ProfilePictureURL { get; set; }

        // Timezone name, no data type given, requires admin

        // User Parents, User data type

        // Parent and child stuff

        /// <summary>
        /// Whether or not the signed-in user can send a private message to the listed user
        /// </summary>
        [JsonProperty("send_message")]
        public int SendMessageStatus { get; set; }

        /// <summary>
        /// Whether or not this user was synced with an external system
        /// </summary>
        [JsonProperty("synced")]
        public bool SyncStatus { get; set; }

        /// <summary>
        /// ID pointing to temporary save of the profile picture upload
        /// </summary>
        [JsonProperty("profile_picture_fid")]
        public int ProfilePictureFileID { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum NameTitle
    {
        Mr,
        Mrs,
        Ms,
        Miss,
        Dr,
        Professor
    }
}