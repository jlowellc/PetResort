using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using ThePetResort.UI.Models;

namespace ThePetResort.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            // Returns the contact form
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel contact)
        {
            // Create the body for the email

            // This assembles the message using the traditional string.Format method
            // var body = string.Format("Name: {0}<br/>Email: {1}<br/>Subject: {2}<br/>Message: {3}", contact.Name, contact.Email, contact.Subject, contact.Message);

            // We can also create the message using the new string interpolation method
            var body = string.Format($"Name: {contact.Name}<br/>Email: {contact.Email}<br/>Subject: {contact.Subject}<br/>Message: {contact.Message}");

            // We need to address our letter
            // We create and configure the Mail Message object
            MailMessage msg = new MailMessage(
                "no-reply@jameslcarter.com", // From address (this MUST be an email on your hosting account)
                "jlcarter.2342@gmail.com", // To address
                contact.Subject, // Subject from the user
                body // message of the email from the user
            );

            // Configure the Mail Message object
            msg.IsBodyHtml = true;
            // msg.CC.Add("dduderstadt@centriq.com"); // Carbon Copy another email address

            // msg.BCC.Add("email@domain.com"); // Adds a blind carbon copy
            msg.Priority = MailPriority.High;

            // Create and configure the SMTP client
            // aka building the post office
            SmtpClient client = new SmtpClient("mail.jameslcarter.com");
            client.Credentials = new NetworkCredential("no-reply@jameslcarter.com", "Donth@ckany1");

            // send the email
            using (client)
            {
                try
                {
                    client.Send(msg);
                }
                catch
                {
                    ViewBag.ErrorMessage = "There was an error sending your email. Please try again.";
                    return View();
                }
            }

            // Send them to the contact confirmation view and pass through
            // the contact information object (contact) to use that
            // information on the confirmation view
            return View("ContactConfirmation", contact);
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}