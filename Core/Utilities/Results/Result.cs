using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess; 
        }

        public Result(bool isSuccess, string message) : this(isSuccess) // bu true false bilgisini diğer cotr'a yaptırmak için ise bu bilgiyi ona gönderiyoruz
        { 
            // IsSuccess = isSuccess; burada bu kodu yazmıyoruz çünkü yukarıdaki constructor'da da aynısını yazdık ve kendimizi tekrar etmiş oluyoruz.
            // bu constuctor'ı çalıştırdığımızda, yani hem mesaj hem true-false bilgisi verdiğimzde aslında hem bu ctor. hem de üstteki ctor açlışır.
            // oyüzden true false bilgisini set etme işini üstteki cotr'a bırakıyoruz ki kendimizi tekrar etmeyelim.
            
            //DRY
            Message = message;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
