using System.Text;
using System;
using System.IO;


namespace Vcard.Services;
using Models;
public class VcardCreator
{
   /*  
    BEGIN:VCARD
    VERSION:3.0
    FN;CHARSET=UTF-8:Mutalib Gozalov
    N;CHARSET=UTF-8:Gozalov;Mutalib;;;
    NICKNAME;CHARSET=UTF-8:Mete
    BDAY:19980415
    EMAIL;CHARSET=UTF-8;type=HOME,INTERNET:mutalib.gezalov.9848@mail.ru
    TEL;TYPE=HOME,VOICE:0515328607
    ADR;CHARSET=UTF-8;TYPE=HOME:;;5-ci Ahmedli street;Baku;;1032;Azerbaijan
    REV:2023-05-09T17:15:42.915Z
    END:VCARD 

    ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffZ")	2015-05-16T05:50:06.7199222-04:00
    */
StringBuilder fugazi = new(
@"
BEGIN:VCARD
VERSION:3.0
FN;CHARSET=UTF-8:<FULL_NAME>
N;CHARSET=UTF-8:<LAST_NAME>;<FIRST_NAME>;;;
NICKNAME;CHARSET=UTF-8:<NICK_NAME>
BDAY:<BIRTH_DAY>
EMAIL;CHARSET=UTF-8;type=HOME,INTERNET:<EMAIL>
TEL;TYPE=HOME,VOICE:<PHONE_NUMBER>
ADR;CHARSET=UTF-8;TYPE=HOME:;;<STREET>;<CITY>;;<POST_CODE>;<COUNTRY>
REV:<REGISTERED_DATE>
END:VCARD 
");
    public void CreateContact(PersonModel person, string CONTACT_NAME )
    {
        fugazi.Replace("<FULL_NAME>", person.FullName)
        .Replace("<LAST_NAME>", person.last)
        .Replace("<FIRST_NAME>", person.first)
        .Replace("<NICK_NAME>", person.NickName)
        .Replace("<BIRTH_DAY>", person.BirthDay.ToString("yyyymmdd"))
        .Replace("<EMAIL>", person.Email)
        .Replace("<PHONE_NUMBER>", person.Phone)
        .Replace("<STREET>", person.Street)
        .Replace("<CITY>", person.City)
        .Replace("<POST_CODE>", person.PostCode.ToString())
        .Replace("<REGISTERED_DATE>", person.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"))
        .Replace("<COUNTRY>", person.Country);


        string path = @"C:\Users\99450\Desktop\RNET102\Tasks\Vcard\CONTACT_NAME.vcf";
        File.WriteAllText(path.Replace("CONTACT_NAME", CONTACT_NAME), fugazi.ToString());
        System.Console.WriteLine(fugazi.ToString());
    }
}
