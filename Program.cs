namespace Read_data_from_file_and_filter_name_change_value_M_F
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    namespace Read_data_from_file
    {
        public class Person
        {
            //instance field
            protected string _name = "";
            protected string _gender = "";
            protected byte _age = 0;

            //instance method
            public string GetName() { return _name; }
            public string GetGender() { return _gender; }
            public byte GetAge() => _age;

            public bool SetData(string data, string delimiter = "/")
            {
                string[] arr = data.Split(delimiter);
                if (arr.Length < 3) return false;
                string name = arr[0].Trim();
                string gender = arr[1].Trim();
                if (byte.TryParse(arr[2], out byte age) == false) return false;
                _name = name;
                _gender = gender;
                _age = age;
                return true;
            }

            public string GetInfo()
            {
                string nameInfo = $"{_name,-30}";
                string genderInfo = $"{_gender,-6}";
                string ageInfo = $"{_age,4}";
                return $"{nameInfo} {genderInfo} {ageInfo}";
            }
        }
    }
}