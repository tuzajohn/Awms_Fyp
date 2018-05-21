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
        public enum UserType { PATIENT, DOCTOR, MANAGEMENT, ALL}
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
                        default:type_ = "info"; break;
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
        public string GetDoctShift(List<string> dayList, List<string> periodList)
        {
            
            var d = string.Empty;
            #region table shit
            d = $@"
            <div class='row'>
                <div class='col-md-12'>
                    <div class='table-responsive'>
                        <table class='table table-bordered'>
                            <thead>
                                <tr>
                                    <th>Day</th>
                                    <th>00:00 - 04:00</th>
                                    <th>04:00 - 08:00</th>
                                    <th>08-00 - 12:00</th>
                                    <th>12:00 - 16:00</th>
                                    <th>16:00 - 20:00</th>
                                    <th>20:00 - 24:00</th>
                                </tr>
                            </thead>
                            <tbody>";
            foreach (var day in dayList)
            {
                d += "<tr>" +
                    "    <td>1</td>" +
                    "    <td>Table cell</td>" +
                    "    <td>Table cell</td>" +
                    "    <td>Table cell</td>" +
                    "    <td>Table cell</td>" +
                    "    <td>Table cell</td>" +
                    "    <td>Table cell</td>";
            }
            d += $@"
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>";
            #endregion
            return d;
        }
    }
}
