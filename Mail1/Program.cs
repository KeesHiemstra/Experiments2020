using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Mail1
{
  class Program
  {
    //https://stackoverflow.com/questions/19910871/adding-image-to-system-net-mail-message
    static void Main(string[] args)
    {
      string body = "<img src=\"cid:Photo\" />";

      byte[] reader = File.ReadAllBytes("Z:\\Tmp\\Milieu.png");
      MemoryStream image1 = new MemoryStream(reader);
      AlternateView av = 
        AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

      LinkedResource headerImage =
        new LinkedResource(image1, MediaTypeNames.Image.Jpeg)
        {
          ContentId = "Photo",
          ContentType = new ContentType("image/jpg")
        };
      av.LinkedResources.Add(headerImage);

      MailMessage message = new MailMessage();
      message.AlternateViews.Add(av);
      message.To.Add("chi@xs4all.nl");
      message.Subject = "Today's photo";
      message.From = new MailAddress("Joost <chi@xs4all.nl>");

      ContentType mimeType = new ContentType("text/html");
      AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
      message.AlternateViews.Add(alternate);

      SmtpClient smtp = new SmtpClient("smtp.xs4all.nl");
      smtp.Send(message);
    }
  }
}
