using System.Collections.Generic;
using FriendOrganizer.Model;

namespace FriendOrganizer.Wrapper
{

    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {
        }

        public int Id => Model.Id;

        public string FirstName
        {
            get => GetValue<string>();
            set
            {
                SetValue<string>(value);
            }
        }

        public string LastName
        {
            get => GetValue<string>();
            set
            {
                SetValue<string>(value);
            }
        }

        public string Email
        {
            get => GetValue<string>();
            set
            {
                SetValue<string>(value);
            }
        }

        public int? ProgrammingLanguageId
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }
        //protected override IEnumerable<string> ValidateProperty(string propertyName)
        //{
        //    switch (propertyName)
        //    {
        //        case nameof(FirstName):
        //            if (string.IsNullOrEmpty(FirstName))
        //            {
        //                yield return "Friend name can't be empty";
        //            }
        //            break;
        //    }
        //}

    }
}
