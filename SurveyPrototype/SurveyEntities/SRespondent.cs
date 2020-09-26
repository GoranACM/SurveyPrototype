/*  
 *  Project: AITResearch
 *  
 *  Developed by: Goran Ilievski
 *  ID: #7108
 *  Date: 30/08/2020
 *  
 *  Subject: Data-Driven Apps
 */

using System;

namespace SurveyPrototype.SurveyEntities
{
    /// <summary>
    /// SRespondent is the object that represents the survey respondent details
    /// </summary>
    public class SRespondent
    {
        public int rID { get; set; }
        public string rFirstName { get; set; }
        public string rLastName { get; set; }
        public DateTime? rDateOfBirth { get; set; }
        public string rPhoneNumber { get; set; }
        public string rIpAddress { get; set; }
        public DateTime rDateStamp { get; set; }
        public int rComplete { get; set; }
    }
}