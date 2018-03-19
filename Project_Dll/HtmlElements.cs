using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Dll
{
    public class HtmlElements
    {
        public enum MessageType {SUCCESS, INFO, ERROR};
        public enum UserType { PATIENT, DOCTOR, MANAGEMENT}
        public string GetMesage(string message, MessageType type, UserType userType)
        {
            var type_ = string.Empty;
            switch (type)
            {
                case MessageType.SUCCESS: type_ = "success"; break;
                case MessageType.INFO:
                    switch (userType)
                    {
                        case UserType.PATIENT: type_ = "primary"; break;
                        case UserType.DOCTOR: type_ = "royal"; break;
                        case UserType.MANAGEMENT: type_ = "warning"; break;
                        default: break;
                    }
                    break;
                case MessageType.ERROR: type_ = "danger"; break;
                default: break;
            }

            var d = string.Empty;
            d = $@"
            <div class='alert alert-{type_} alert-light alert-dismissible' role='alert'>
                <button type='button' class='close' data-dismiss='alert' aria-label='Close'>
                    <i class='zmdi zmdi-close'></i>
                </button>
                <strong> {message}</strong> 
            </div>";

            return d;
        }
    }
}
