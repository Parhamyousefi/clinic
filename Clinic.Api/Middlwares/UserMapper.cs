namespace Clinic.Api.Middlwares
{
    public static class UserMapper
    {
        public static string[] MapRole(string roleId)
        {
            string[] result = new string[2];
            switch (roleId)
            {
                case "2":
                    result[0] = "Admin";
                    result[1] = "QE5#AGj@@UV+!Ad2@!msuv6!";
                    break;
                case "7":
                    result[0] = "Secretary-Reception";
                    result[1] = "M)tCXD%Y@uEQTj*@FLmuD)P$";
                    break;
                case "9":
                    result[0] = "Doctor";
                    result[1] = "cMI(3H!++nysmyT5CwXe*sVf";
                    break;
                case "10":
                    result[0] = "Technician";
                    result[1] = "S%T6RLp2vtABa@rfTahIg8JZ";
                    break;
                case "11":
                    result[0] = "Medical Record";
                    result[1] = "R#cjGk$RjeXxy%m3bB5KxKUR";
                    break;
                case "12":
                    result[0] = "Inpatient";
                    result[1] = "@#(RES2^yQ%AwrJ9(P&rq7&X";
                    break;
                case "13":
                    result[0] = "Supervisor";
                    result[1] = "z&pMHUN^K3S#DR@P5+RZbKnB";
                    break;
                case "14":
                    result[0] = "Finance";
                    result[1] = "%N!jpwfkpMqdw&4W5)qAr79y";
                    break;
                case "15":
                    result[0] = "Assistant";
                    result[1] = "es*y5#WQwPI3^VLhdcm#@T3E";
                    break;
                case "16":
                    result[0] = "Manager";
                    result[1] = "x(CtV8C5@yarxzd$xPe$F%uv";
                    break;
                case "17":
                    result[0] = "Secretary Mix";
                    result[1] = "WJDNcw%+nv74^Zrms(G%E!@3";
                    break;
                case "18":
                    result[0] = "Manager-Test";
                    result[1] = "H*5#H)Wf8LRTw%!a#(cK44kC";
                    break;
                case "19":
                    result[0] = "Research";
                    result[1] = "uM54#sJa(3$qjB64rjvT3x24";
                    break;
            }
            return result;
        }
    }
}
